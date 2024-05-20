using FluentValidation;
using QuakeAnalitika.Model.Open;

namespace QuakeAnalitika.Model.Open.Validation;

public class UserValidator : AbstractValidator<UserEditDto>
{

    /// <summary>
    /// FluentValidation validator for the object.
    /// </summary>
    public UserValidator()
    {
        RuleFor(procedure => procedure.Email).NotNull().NotEmpty().MinimumLength(10).MaximumLength(60);
        RuleFor(procedure => procedure.Password).NotNull().NotEmpty().MinimumLength(10).MaximumLength(50);
    }

}
