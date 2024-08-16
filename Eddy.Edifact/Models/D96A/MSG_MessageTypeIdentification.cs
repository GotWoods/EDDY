using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("MSG")]
public class MSG_MessageTypeIdentification : EdifactSegment
{
	[Position(1)]
	public C709_MessageIdentifier MessageIdentifier { get; set; }

	[Position(2)]
	public string ClassDesignatorCoded { get; set; }

	[Position(3)]
	public string MaintenanceOperationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MSG_MessageTypeIdentification>(this);
		validator.Required(x=>x.MessageIdentifier);
		validator.Length(x => x.ClassDesignatorCoded, 1, 3);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		return validator.Results;
	}
}
