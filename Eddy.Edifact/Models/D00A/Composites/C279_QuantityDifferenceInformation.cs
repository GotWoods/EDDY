using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C279")]
public class C279_QuantityDifferenceInformation : EdifactComponent
{
	[Position(1)]
	public string QuantityVarianceValue { get; set; }

	[Position(2)]
	public string QuantityTypeCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C279_QuantityDifferenceInformation>(this);
		validator.Required(x=>x.QuantityVarianceValue);
		validator.Length(x => x.QuantityVarianceValue, 1, 15);
		validator.Length(x => x.QuantityTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
