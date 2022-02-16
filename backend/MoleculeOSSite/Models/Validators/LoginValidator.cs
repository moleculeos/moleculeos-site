using FluentValidation;
using MoleculeOSSite.ModelsDTO;

namespace MoleculeOSSite.Models.Validators
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(x=>x.Login).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
        }
    }
}
