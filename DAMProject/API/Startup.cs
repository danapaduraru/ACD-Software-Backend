using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Implementations;
using Services.Interfaces;

namespace API
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<Context>(options =>
            {
                //options.UseSqlServer(@"Data Source=DESKTOP-1PE5EKU\SQLEXPRESS;Initial Catalog=DAMProject; Trusted_Connection=True;");
                options.UseSqlServer(@"Data Source=DESKTOP-RG20533\SQLEXPRESS;Initial Catalog=dam; Trusted_Connection=True;");
                //options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DAM; Trusted_Connection=True;");
            });

            services.AddSingleton(DAMInfrastructure.AutoMapper.Configure().CreateMapper());

            services.AddScoped<IPersonsService, PersonsService>();
            services.AddScoped<IPersonsRepository, PersonsRepository>();

            services.AddScoped<IQuestionsService, QuestionsService>();
            services.AddScoped<IQuestionsRepository, QuestionsRepository>();

            services.AddScoped<ITestsService, TestsService>();
            services.AddScoped<ITestsRepository, TestsRepository>();

            services.AddScoped<IJobPositionsService, JobPositionsService>();
            services.AddScoped<IJobPositionsRepository, JobPositionsRepository>();

            services.AddScoped<IInterviewsService, InterviewsService>();
            services.AddScoped<IInterviewsRepository, InterviewsRepository>();

            services.AddScoped<IApplicationsService, ApplicationsService>();
            services.AddScoped<IApplicationsRepository, ApplicationsRepository>();

            services.AddScoped<IQuestionResponsesService, QuestionResponsesService>();
            services.AddScoped<IQuestionResponsesRepository, QuestionResponsesRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000",
                                                          "https://localhost:3000");
                                  });
            });

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DAM v1");
            });
        }
    }
}
