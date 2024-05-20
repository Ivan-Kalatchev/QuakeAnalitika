using FluentValidation;

namespace QuakeAnalitika.Model.Open.Validation;

public class CredentialsValidator : AbstractValidator<CredentialsDto>
{

    /// <summary>
    /// FluentValidation validator for the object.
    /// </summary>
    public CredentialsValidator()
    {
        RuleFor(procedure => procedure.UserName).NotNull().NotEmpty().MinimumLength(3).MaximumLength(20);
        RuleFor(procedure => procedure.Password).NotNull().NotEmpty().MinimumLength(10).MaximumLength(50);
    }

}
