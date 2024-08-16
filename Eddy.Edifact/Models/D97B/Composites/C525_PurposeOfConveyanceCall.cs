using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97B.Composites;

[Segment("C525")]
public class C525_PurposeOfConveyanceCall : EdifactComponent
{
	[Position(1)]
	public string PurposeOfConveyanceCallCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string PurposeOfConveyanceCall { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C525_PurposeOfConveyanceCall>(this);
		validator.Length(x => x.PurposeOfConveyanceCallCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.PurposeOfConveyanceCall, 1, 35);
		return validator.Results;
	}
}