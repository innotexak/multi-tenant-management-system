using AutoMapper;
using MediatR;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Application.projects.Queries.TastItemList;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.projects.Queries.TaskItemDetails
{
    public class TaskItemQueryHandler : IRequestHandler<TaskItemQuery, TaskItemDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskItemRepository _taskItemRepository;

        public TaskItemQueryHandler(IMapper mapper, ITaskItemRepository taskItemRepository)
        {
            _mapper = mapper;
            _taskItemRepository = taskItemRepository;
        }
        public async Task<TaskItemDetailResponse> Handle(TaskItemQuery request, CancellationToken cancellationToken)
        {

            var result = await _taskItemRepository.GetSingleItem(request.TaskItemId);

            if (result == null)
            {
                throw new KeyNotFoundException($"Task item with ID {request.TaskItemId} was not found.");
            }

           var mappedResult = _mapper.Map<TaskItemListVn>(result);

            return new TaskItemDetailResponse
            {
                Success = true,
                Message = "Data retrieved successfully",
                Data = mappedResult
            };

        }
    }
}
