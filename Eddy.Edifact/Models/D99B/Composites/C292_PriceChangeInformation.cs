using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C292")]
public class C292_PriceChangeInformation : EdifactComponent
{
	[Position(1)]
	public string PriceChangeIndicatorCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C292_PriceChangeInformation>(this);
		validator.Required(x=>x.PriceChangeIndicatorCoded);
		validator.Length(x => x.PriceChangeIndicatorCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
