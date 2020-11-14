using CSharpFunctionalExtensions;
using Models.Interview;
using Models.ModelHelper.RelationshipDTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IInterviewsService
    {
        Task<Result<IEnumerable<InterviewDTO>>> GetAllAsync();
        Task<Result<InterviewDTO>> GetByIdAsync(Guid id);
        Task<Result<InterviewDTO>> GetByPersonIdAsync(Guid id);
        Task<Result<InterviewDTO>> GetByApplicationIdAsync(Guid id);
        Task<Result> AddAsync(AddInterviewDTO addInterviewDTO);
        Task<Result> AddTestToInterviewAsync(TestsToInterviewsRelationDTO TIRelDTO);
        Task<Result> UpdateAsync(Guid id, UpdateInterviewDTO updateInterviewDTO);
    }
}
