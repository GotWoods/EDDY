using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C552")]
public class C552_AllowanceChargeInformation : EdifactComponent
{
	[Position(1)]
	public string AllowanceOrChargeIdentifier { get; set; }

	[Position(2)]
	public string AllowanceOrChargeIdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C552_AllowanceChargeInformation>(this);
		validator.Length(x => x.AllowanceOrChargeIdentifier, 1, 35);
		validator.Length(x => x.AllowanceOrChargeIdentificationCode, 1, 3);
		return validator.Results;
	}
}
