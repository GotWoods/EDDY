using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C525")]
public class C525_PurposeOfConveyanceCall : EdifactComponent
{
	[Position(1)]
	public string ConveyanceCallPurposeDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ConveyanceCallPurposeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C525_PurposeOfConveyanceCall>(this);
		validator.Length(x => x.ConveyanceCallPurposeDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ConveyanceCallPurposeDescription, 1, 35);
		return validator.Results;
	}
}
