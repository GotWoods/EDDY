using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C292")]
public class C292_PriceChangeInformation : EdifactComponent
{
	[Position(1)]
	public string PriceChangeIndicatorCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C292_PriceChangeInformation>(this);
		validator.Required(x=>x.PriceChangeIndicatorCoded);
		validator.Length(x => x.PriceChangeIndicatorCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
