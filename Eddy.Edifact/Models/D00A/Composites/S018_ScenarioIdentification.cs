using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S018")]
public class S018_ScenarioIdentification : EdifactComponent
{
	[Position(1)]
	public string ScenarioIdentification { get; set; }

	[Position(2)]
	public string ScenarioVersionNumber { get; set; }

	[Position(3)]
	public string ScenarioReleaseNumber { get; set; }

	[Position(4)]
	public string ControllingAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S018_ScenarioIdentification>(this);
		validator.Required(x=>x.ScenarioIdentification);
		validator.Length(x => x.ScenarioIdentification, 1, 14);
		validator.Length(x => x.ScenarioVersionNumber, 1, 3);
		validator.Length(x => x.ScenarioReleaseNumber, 1, 3);
		validator.Length(x => x.ControllingAgencyCoded, 1, 3);
		return validator.Results;
	}
}
