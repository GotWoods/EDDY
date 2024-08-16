using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C079")]
public class C079_ComputerEnvironmentIdentification : EdifactComponent
{
	[Position(1)]
	public string ComputerEnvironmentCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string ComputerEnvironment { get; set; }

	[Position(5)]
	public string Version { get; set; }

	[Position(6)]
	public string Release { get; set; }

	[Position(7)]
	public string IdentityNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C079_ComputerEnvironmentIdentification>(this);
		validator.Length(x => x.ComputerEnvironmentCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.ComputerEnvironment, 1, 35);
		validator.Length(x => x.Version, 1, 9);
		validator.Length(x => x.Release, 1, 9);
		validator.Length(x => x.IdentityNumber, 1, 35);
		return validator.Results;
	}
}
