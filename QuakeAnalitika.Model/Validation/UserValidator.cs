using FluentValidation;

namespace QuakeAnalitika.Model.Validation;

public class UserValidator : AbstractValidator<User>
{

    /// <summary>
    /// FluentValidation validator for the object.
    /// </summary>
    public UserValidator()
    {
        RuleFor(procedure => procedure.Email).NotNull().NotEmpty().MinimumLength(10).MaximumLength(60);
        RuleFor(procedure => procedure.Password).NotNull().NotEmpty().MinimumLength(10).MaximumLength(50);
        RuleFor(procedure => procedure.ProfileImage).NotNull().NotEmpty().MinimumLength(50);
    }

}
