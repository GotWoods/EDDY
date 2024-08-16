using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Models.D98A;

[Segment("CED")]
public class CED_ComputerEnvironmentDetails : EdifactSegment
{
	[Position(1)]
	public string ComputerEnvironmentDetailsQualifier { get; set; }

	[Position(2)]
	public C079_ComputerEnvironmentIdentification ComputerEnvironmentIdentification { get; set; }

	[Position(3)]
	public string FileGeneratingCommand { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CED_ComputerEnvironmentDetails>(this);
		validator.Required(x=>x.ComputerEnvironmentDetailsQualifier);
		validator.Required(x=>x.ComputerEnvironmentIdentification);
		validator.Length(x => x.ComputerEnvironmentDetailsQualifier, 1, 3);
		validator.Length(x => x.FileGeneratingCommand, 1, 35);
		return validator.Results;
	}
}