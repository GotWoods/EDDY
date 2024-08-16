using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C292")]
public class C292_PriceChangeInformation : EdifactComponent
{
	[Position(1)]
	public string PriceChangeTypeCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C292_PriceChangeInformation>(this);
		validator.Required(x=>x.PriceChangeTypeCode);
		validator.Length(x => x.PriceChangeTypeCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
