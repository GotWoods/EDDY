using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.Elements;

public class C507_DateTimePeriod : IElement 
{
    [Position(1)]
    public string DateOrTimeOrPeriodFunctionCodeQualifier { get; set; }

    [Position(2)]
    public string DateOrTimeOrPeriodText { get; set; }

    [Position(3)]
    public string DateOrTimeOrPeriodFormatCode { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<C507_DateTimePeriod> (this);
        validator.Length(x => x.DateOrTimeOrPeriodFunctionCodeQualifier, 1, 3);
        validator.Length(x => x.DateOrTimeOrPeriodText, 1, 35);
        validator.Length(x => x.DateOrTimeOrPeriodFormatCode, 1, 3);
    }
}