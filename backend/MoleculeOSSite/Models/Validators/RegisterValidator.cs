using FluentValidation;
using MoleculeOSSite.Entities;

namespace MoleculeOSSite.Models.Validators
{
    public class RegisterValidator:AbstractValidator<User>
    {
        public RegisterValidator(MyDbContext dbcontext)
        {
            RuleFor(x=>x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.PasswordHash).NotEmpty().MinimumLength(6);
            RuleFor(x=>x.ConfirmPassword).Equal(u=>u.PasswordHash);
            RuleFor(x => x.Email).Custom((value, context) =>
            {
                var emailExist = dbcontext.Users.Any(u=>u.Email == value);
                if (emailExist)
                    context.AddFailure("Email", "Email is already taken");
            });
        }
    }
}
