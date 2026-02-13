using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Application.Common.Interfaces.Authorization;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.projects.Queries.TastItemList
{
    public class TaskItemListQueryHandler : IRequestHandler<TaskItemListQuery, TaskItemListQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly ICurrentUserService _currentService;
        private readonly IProjectAuthorizationService _projectAuthorizationService;

        public TaskItemListQueryHandler(
            IMapper mapper, 
            ITaskItemRepository taskItemRepository, 
            ICurrentUserService currentUserService,
              IProjectAuthorizationService projectAuthorizationService
            )
        {
            _mapper = mapper;
            _taskItemRepository = taskItemRepository;
            _currentService = currentUserService;
            _projectAuthorizationService= projectAuthorizationService;

        }
        public async Task<TaskItemListQueryResponse> Handle(TaskItemListQuery request, CancellationToken cancellationToken)
        {
            var currentUserId = _currentService.UserId;
            var currentUserRole = _currentService.Role;
            var isProjectMember = await _projectAuthorizationService.IsProjectMemberAsync(request.ProjectId, (Guid)currentUserId);
            if (!isProjectMember && currentUserRole != "Admin")
            {
                throw new UnauthorizedAccessException("You are not authorized to access this resources.");
            }

            var taskItems = await _taskItemRepository.GetItems(request.ProjectId);

            var taskItemVns = _mapper.Map<List<TaskItemListVn>>(taskItems);
            return new TaskItemListQueryResponse
            {
                Success = true,
                Message = "Task items retrieved successfully.",
                Data = taskItemVns
            };
        }
    }
}
