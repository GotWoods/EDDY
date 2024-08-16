using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C501")]
public class C501_PercentageDetails : EdifactComponent
{
	[Position(1)]
	public string PercentageQualifier { get; set; }

	[Position(2)]
	public string Percentage { get; set; }

	[Position(3)]
	public string PercentageBasisCoded { get; set; }

	[Position(4)]
	public string CodeListQualifier { get; set; }

	[Position(5)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C501_PercentageDetails>(this);
		validator.Required(x=>x.PercentageQualifier);
		validator.Length(x => x.PercentageQualifier, 1, 3);
		validator.Length(x => x.Percentage, 1, 10);
		validator.Length(x => x.PercentageBasisCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
