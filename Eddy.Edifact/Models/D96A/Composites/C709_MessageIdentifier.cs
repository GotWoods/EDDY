using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C709")]
public class C709_MessageIdentifier : EdifactComponent
{
	[Position(1)]
	public string MessageTypeIdentifier { get; set; }

	[Position(2)]
	public string Version { get; set; }

	[Position(3)]
	public string Release { get; set; }

	[Position(4)]
	public string ControlAgency { get; set; }

	[Position(5)]
	public string AssociationAssignedIdentification { get; set; }

	[Position(6)]
	public string RevisionNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C709_MessageIdentifier>(this);
		validator.Required(x=>x.MessageTypeIdentifier);
		validator.Required(x=>x.Version);
		validator.Required(x=>x.Release);
		validator.Required(x=>x.ControlAgency);
		validator.Length(x => x.MessageTypeIdentifier, 1, 6);
		validator.Length(x => x.Version, 1, 9);
		validator.Length(x => x.Release, 1, 9);
		validator.Length(x => x.ControlAgency, 1, 2);
		validator.Length(x => x.AssociationAssignedIdentification, 1, 6);
		validator.Length(x => x.RevisionNumber, 1, 6);
		return validator.Results;
	}
}
