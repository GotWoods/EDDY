using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D02A.Composites;

[Segment("E025")]
public class E025_BasisOfServiceInformation : EdifactComponent
{
	[Position(1)]
	public string ServiceBasisCodeQualifier { get; set; }

	[Position(2)]
	public string ProductIdentifier { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	[Position(4)]
	public string DateOrTimeOrPeriodText { get; set; }

	[Position(5)]
	public string DateOrTimeOrPeriodFormatCode { get; set; }

	[Position(6)]
	public string MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E025_BasisOfServiceInformation>(this);
		validator.Required(x=>x.ServiceBasisCodeQualifier);
		validator.Required(x=>x.ProductIdentifier);
		validator.Length(x => x.ServiceBasisCodeQualifier, 1, 3);
		validator.Length(x => x.ProductIdentifier, 1, 35);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.DateOrTimeOrPeriodText, 1, 35);
		validator.Length(x => x.DateOrTimeOrPeriodFormatCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		return validator.Results;
	}
}
