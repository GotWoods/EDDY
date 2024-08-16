using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E025")]
public class E025_BasisOfServiceInformation : EdifactComponent
{
	[Position(1)]
	public string BasisOfServiceCodeQualifier { get; set; }

	[Position(2)]
	public string ProductIdentifier { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	[Position(4)]
	public string DateTimePeriodValue { get; set; }

	[Position(5)]
	public string DateTimePeriodFormatCode { get; set; }

	[Position(6)]
	public string MonetaryAmountValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E025_BasisOfServiceInformation>(this);
		validator.Required(x=>x.BasisOfServiceCodeQualifier);
		validator.Required(x=>x.ProductIdentifier);
		validator.Length(x => x.BasisOfServiceCodeQualifier, 1, 3);
		validator.Length(x => x.ProductIdentifier, 1, 35);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.DateTimePeriodValue, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatCode, 1, 3);
		validator.Length(x => x.MonetaryAmountValue, 1, 35);
		return validator.Results;
	}
}
