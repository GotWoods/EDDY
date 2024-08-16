using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C279")]
public class C279_QuantityDifferenceInformation : EdifactComponent
{
	[Position(1)]
	public string QuantityDifference { get; set; }

	[Position(2)]
	public string QuantityTypeCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C279_QuantityDifferenceInformation>(this);
		validator.Required(x=>x.QuantityDifference);
		validator.Length(x => x.QuantityDifference, 1, 15);
		validator.Length(x => x.QuantityTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
