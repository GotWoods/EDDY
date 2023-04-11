using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C033")]
public class C033_SecurityTokenValue : EdiX12Component
{
    [Position(00)]
    public string SecurityValueQualifier { get; set; }

    [Position(01)]
    public string EncodedSecurityValue { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C033_SecurityTokenValue>(this);
        validator.Required(x => x.SecurityValueQualifier);
        validator.Required(x => x.EncodedSecurityValue);
        validator.Length(x => x.SecurityValueQualifier, 3);
        validator.Length(x => x.EncodedSecurityValue, 1, 2147483647);
        return validator.Results;
    }
}