using FluentValidation;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.Auth.Command.Register
{
    public class RegisterCommandValidator: AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator(IAsyncRepository<User> userRepository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(async (email, cancellation) =>
                {
                    var exists = await userRepository.ExistsAsync(u => u.Email == email);
                    return !exists;
                }).WithMessage("Email already exists.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

        }
    }
}