using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("DII")]
public class DII_DirectoryIdentification : EdifactSegment
{
	[Position(1)]
	public string Version { get; set; }

	[Position(2)]
	public string Release { get; set; }

	[Position(3)]
	public string DirectoryStatus { get; set; }

	[Position(4)]
	public string ControlAgency { get; set; }

	[Position(5)]
	public string LanguageNameCode { get; set; }

	[Position(6)]
	public string MaintenanceOperationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DII_DirectoryIdentification>(this);
		validator.Required(x=>x.Version);
		validator.Required(x=>x.Release);
		validator.Length(x => x.Version, 1, 9);
		validator.Length(x => x.Release, 1, 9);
		validator.Length(x => x.DirectoryStatus, 1, 3);
		validator.Length(x => x.ControlAgency, 1, 2);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		return validator.Results;
	}
}
