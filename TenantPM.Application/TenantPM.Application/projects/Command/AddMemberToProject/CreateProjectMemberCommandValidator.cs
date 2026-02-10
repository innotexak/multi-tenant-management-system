using FluentValidation;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.projects.Command.AddMemberToProject
{
    public class CreateProjectMemberCommandValidator: AbstractValidator<CreateProjectMemberCommand>
    {
        private readonly IAsyncRepository<Project> _projectRepository;
        private readonly IAsyncRepository<User> _userRepository;

        public CreateProjectMemberCommandValidator(IAsyncRepository<Project> projectRepository, IAsyncRepository<User> userRepository )
        {
            _projectRepository = projectRepository;
            _userRepository = userRepository;

            //RuleFor(x => x.ProjectId)
            //    .NotEmpty().WithMessage("ProjectId is required.")
            //    .MustAsync(async (projectId, cancellation) =>
            //    {
            //        var project = await _projectRepository.ExistsAsync(u=>u.Id == projectId);
            //        return project != null;
            //    }).WithMessage("Project with the specified ID does not exist.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId is required.")
                 .MustAsync(async (userId, cancellation) =>
                 {
                     var project = await _userRepository.ExistsAsync(u => u.Id == userId);
                     return project != null;
                 }).WithMessage("User with the specified ID does not exist.");

            RuleFor(x => x.ProjectRole)
                .IsInEnum().WithMessage("Invalid project role specified.");
        }
    }
}