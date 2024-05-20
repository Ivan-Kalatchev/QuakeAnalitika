using FluentValidation;

namespace QuakeAnalitika.Model.Open.Validation;

public class ReportValidator : AbstractValidator<Report>
{

    /// <summary>
    /// FluentValidation validator for the object.
    /// </summary>
    public ReportValidator()
    {
        RuleFor(procedure => procedure.Lang).NotNull();
        RuleFor(procedure => procedure.Lat).NotNull();
        RuleFor(procedure => procedure.Amount).NotNull().InclusiveBetween(1,5);
    }

}
