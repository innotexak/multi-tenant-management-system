using FluentValidation;
using TenantPM.Application.Common.Interfaces;
using TenantPM.Domain.Entities;

namespace TenantPM.Application.Auth.Command.Login
{
    public class LoginCommandValidator: AbstractValidator<LoginCommand>
    {

        public LoginCommandValidator(IAsyncRepository<User> userRepository)
        {
    

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(async (email, cancellation) =>
                {
                    var user = await userRepository.ExistsAsync(u => u.Email == email);
                    return user != null;
                }).WithMessage("Email does not exist.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");
        }
    }
}