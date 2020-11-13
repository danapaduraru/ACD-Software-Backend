using CSharpFunctionalExtensions;
using Models.Application;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IApplicationsService
    {
        Task<Result<IEnumerable<ApplicationDTO>>> GetAllAsync();
        Task<Result<IEnumerable<ApplicationDTO>>> GetAllByJobIdAsync(Guid id);
        Task<Result<IEnumerable<ApplicationDTO>>> GetAllByApplicantIdAsync(Guid id);
        Task<Result<ApplicationDTO>> GetByIdAsync(Guid id);
        Task<Result> AddAsync(AddApplicationDTO personDTO);
        Task<Result> UpdateAsync(Guid id, UpdateApplicationDTO person);
    }
}
