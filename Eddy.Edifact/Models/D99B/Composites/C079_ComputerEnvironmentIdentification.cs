using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C079")]
public class C079_ComputerEnvironmentIdentification : EdifactComponent
{
	[Position(1)]
	public string ComputerEnvironmentCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ComputerEnvironment { get; set; }

	[Position(5)]
	public string Version { get; set; }

	[Position(6)]
	public string Release { get; set; }

	[Position(7)]
	public string ObjectIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C079_ComputerEnvironmentIdentification>(this);
		validator.Length(x => x.ComputerEnvironmentCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ComputerEnvironment, 1, 35);
		validator.Length(x => x.Version, 1, 9);
		validator.Length(x => x.Release, 1, 9);
		validator.Length(x => x.ObjectIdentifier, 1, 35);
		return validator.Results;
	}
}
