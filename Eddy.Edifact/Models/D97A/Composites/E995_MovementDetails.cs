using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E995")]
public class E995_MovementDetails : EdifactComponent
{
	[Position(1)]
	public string ServiceRequirementCoded { get; set; }

	[Position(2)]
	public string Date { get; set; }

	[Position(3)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E995_MovementDetails>(this);
		validator.Length(x => x.ServiceRequirementCoded, 1, 3);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.Time, 4);
		return validator.Results;
	}
}
