using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C549")]
public class C549_MonetaryAmountFunction : EdifactComponent
{
	[Position(1)]
	public string MonetaryAmountFunctionDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string MonetaryAmountFunctionDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C549_MonetaryAmountFunction>(this);
		validator.Length(x => x.MonetaryAmountFunctionDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.MonetaryAmountFunctionDescription, 1, 70);
		return validator.Results;
	}
}
