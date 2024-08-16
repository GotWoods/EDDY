using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("CED")]
public class CED_ComputerEnvironmentDetails : EdifactSegment
{
	[Position(1)]
	public string ComputerEnvironmentDetailsCodeQualifier { get; set; }

	[Position(2)]
	public C079_ComputerEnvironmentIdentification ComputerEnvironmentIdentification { get; set; }

	[Position(3)]
	public string FileGenerationCommandName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CED_ComputerEnvironmentDetails>(this);
		validator.Required(x=>x.ComputerEnvironmentDetailsCodeQualifier);
		validator.Required(x=>x.ComputerEnvironmentIdentification);
		validator.Length(x => x.ComputerEnvironmentDetailsCodeQualifier, 1, 3);
		validator.Length(x => x.FileGenerationCommandName, 1, 35);
		return validator.Results;
	}
}
