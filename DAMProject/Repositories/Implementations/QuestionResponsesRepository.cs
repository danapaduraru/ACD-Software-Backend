using CSharpFunctionalExtensions;
using Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class QuestionResponsesRepository: IQuestionResponsesRepository
    {
        private readonly Context _context;

        public QuestionResponsesRepository(Context context)
        {
            _context = context;
        }

        public async Task<Result> AddAsync(QuestionResponse questionResponse)
        {
            try
            {
                var questions = await _context.TestsToQuestions.Where(ttq => ttq.TestId == questionResponse.TestId).Select(ttq => ttq.Question).ToListAsync().ConfigureAwait(true);
                var myquestion = questions.Where(q => q.QuestionId == questionResponse.QuestionId).FirstOrDefault();
                if (myquestion.QuestionType == Helper.QuestionType.OneChoice)
                {
                    if (questionResponse.Answer == myquestion.CorrectAnswer.ToString())
                        questionResponse.CheckAnswer = Helper.CheckAnswer.Correct;
                    else
                        questionResponse.CheckAnswer = Helper.CheckAnswer.Wrong;
                }
                else
                    questionResponse.CheckAnswer = Helper.CheckAnswer.InReview;

                if (questionResponse.CheckAnswer == Helper.CheckAnswer.Correct)
                {
                    var testToInterview = await _context.TestsToInterviews.Where(a => a.TestId == questionResponse.TestId && a.InterviewId == questionResponse.InterviewId).SingleOrDefaultAsync().ConfigureAwait(true);
                    var test = await _context.Tests.Where(t => t.TestId == questionResponse.TestId).SingleOrDefaultAsync().ConfigureAwait(true);
                    var questionScore = test.MaximumScore / questions.Count;
                    testToInterview.UserScore += questionScore;
                }
                

                var result = await _context.QuestionResponses.AddAsync(questionResponse).ConfigureAwait(true);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success(result);
            }
            catch (Exception e)
            {
                return Result.Failure("Exception: " + e.Message);
            }
        }

        public async Task<Result<IQueryable<QuestionResponse>>> GetAllAsync()
        {
            try
            {
                var result = await _context.QuestionResponses.ToListAsync().ConfigureAwait(true);

                return Result.Success(result.AsQueryable());
            }
            catch (Exception e)
            {
                return Result.Failure<IQueryable<QuestionResponse>>("Exception: " + e.Message);
            }
        }

        public async Task<Result<QuestionResponse>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.QuestionResponses.Where(questionResponse => questionResponse.QuestionId == id).SingleOrDefaultAsync();
                if (result != default(QuestionResponse))
                    return Result.Success(result);
                return Result.Failure<QuestionResponse>("Exception: " + "QuestionResponse not found");
            }
            catch (Exception e)
            {
                return Result.Failure<QuestionResponse>("Exception: " + e.Message);
            }
        }

        public async Task<Result<IQueryable<QuestionResponse>>> GetAllResponsesForSpecificTestAsync(Guid interviewId, Guid testId)
        {
            try
            {
                var result = await _context.QuestionResponses.Where(questionResponse => questionResponse.InterviewId == interviewId && questionResponse.TestId == testId).ToListAsync().ConfigureAwait(true);
                if (result.Any())
                    return Result.Success(result.AsQueryable());
                return Result.Failure<IQueryable<QuestionResponse>>("Exception: " + "QuestionResponse not found");
            }
            catch (Exception e)
            {
                return Result.Failure<IQueryable<QuestionResponse>>("Exception: " + e.Message);
            }
        }

        public async Task<Result<QuestionResponse>> GetResponseForQuestionAsync(Guid interviewId, Guid testId, Guid questionID)
        {
            try
            {
                var result = await _context.QuestionResponses.Where(questionResponse => questionResponse.InterviewId == interviewId && questionResponse.TestId == testId && questionResponse.QuestionId == questionID).SingleOrDefaultAsync().ConfigureAwait(true);
                if (result != default(QuestionResponse))
                    return Result.Success(result);
                return Result.Failure<QuestionResponse>("Exception: " + "QuestionResponse not found");
            }
            catch (Exception e)
            {
                return Result.Failure<QuestionResponse>("Exception: " + e.Message);
            }
        }
    }
}
