using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("DII")]
public class DII_DirectoryIdentification : EdifactSegment
{
	[Position(1)]
	public string VersionIdentifier { get; set; }

	[Position(2)]
	public string ReleaseIdentifier { get; set; }

	[Position(3)]
	public string DirectoryStatusIdentifier { get; set; }

	[Position(4)]
	public string ControllingAgencyIdentifier { get; set; }

	[Position(5)]
	public string LanguageNameCode { get; set; }

	[Position(6)]
	public string MaintenanceOperationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DII_DirectoryIdentification>(this);
		validator.Required(x=>x.VersionIdentifier);
		validator.Required(x=>x.ReleaseIdentifier);
		validator.Length(x => x.VersionIdentifier, 1, 9);
		validator.Length(x => x.ReleaseIdentifier, 1, 9);
		validator.Length(x => x.DirectoryStatusIdentifier, 1, 3);
		validator.Length(x => x.ControllingAgencyIdentifier, 1, 2);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		return validator.Results;
	}
}
