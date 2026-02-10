using AutoMapper;
using MediatR;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Domain.Entities;


namespace TenantPM.Application.projects.Command.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskCommandResponse>
    {
        private readonly IAsyncRepository<Project> _projectRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<TaskItem> _taskItemRepository;

        public CreateTaskCommandHandler(IMapper mapper, IAsyncRepository<TaskItem> taskItemRepository, IAsyncRepository<Project> projectRepository)
        {
           _projectRepository = projectRepository;
            _mapper = mapper;
            _taskItemRepository = taskItemRepository;   
        }
        public async Task<CreateTaskCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTaskCommandValidator(_projectRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid) { 
                var response = new CreateTaskCommandResponse
                {
                    Success = false,
                    Message = "Validation failed",
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                };
                return response;
            }

            var taskItem = _mapper.Map<TaskItem>(request);

            var createdTaskItem = await _taskItemRepository.AddAsync(taskItem);

           return new CreateTaskCommandResponse
            {
                Success = true,
                Message = "Task created successfully",
                Data = createdTaskItem.Id
            };
        }
    }
}
