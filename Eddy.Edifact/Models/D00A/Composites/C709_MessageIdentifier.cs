using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C709")]
public class C709_MessageIdentifier : EdifactComponent
{
	[Position(1)]
	public string MessageTypeCode { get; set; }

	[Position(2)]
	public string VersionIdentifier { get; set; }

	[Position(3)]
	public string ReleaseIdentifier { get; set; }

	[Position(4)]
	public string ControllingAgencyIdentifier { get; set; }

	[Position(5)]
	public string MessageImplementationIdentificationCode { get; set; }

	[Position(6)]
	public string RevisionIdentifier { get; set; }

	[Position(7)]
	public string DocumentStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C709_MessageIdentifier>(this);
		validator.Required(x=>x.MessageTypeCode);
		validator.Length(x => x.MessageTypeCode, 1, 6);
		validator.Length(x => x.VersionIdentifier, 1, 9);
		validator.Length(x => x.ReleaseIdentifier, 1, 9);
		validator.Length(x => x.ControllingAgencyIdentifier, 1, 2);
		validator.Length(x => x.MessageImplementationIdentificationCode, 1, 6);
		validator.Length(x => x.RevisionIdentifier, 1, 6);
		validator.Length(x => x.DocumentStatusCode, 1, 3);
		return validator.Results;
	}
}
