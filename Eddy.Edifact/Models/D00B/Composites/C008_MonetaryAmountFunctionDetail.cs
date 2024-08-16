using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C008")]
public class C008_MonetaryAmountFunctionDetail : EdifactComponent
{
	[Position(1)]
	public string MonetaryAmountFunctionDetailDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string MonetaryAmountFunctionDetailDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C008_MonetaryAmountFunctionDetail>(this);
		validator.Length(x => x.MonetaryAmountFunctionDetailDescriptionCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.MonetaryAmountFunctionDetailDescription, 1, 70);
		return validator.Results;
	}
}
