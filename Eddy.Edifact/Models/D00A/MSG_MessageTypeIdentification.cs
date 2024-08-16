using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("MSG")]
public class MSG_MessageTypeIdentification : EdifactSegment
{
	[Position(1)]
	public C709_MessageIdentifier MessageIdentifier { get; set; }

	[Position(2)]
	public string DesignatedClassCode { get; set; }

	[Position(3)]
	public string MaintenanceOperationCode { get; set; }

	[Position(4)]
	public C941_Relationship Relationship { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MSG_MessageTypeIdentification>(this);
		validator.Required(x=>x.MessageIdentifier);
		validator.Length(x => x.DesignatedClassCode, 1, 3);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		return validator.Results;
	}
}
