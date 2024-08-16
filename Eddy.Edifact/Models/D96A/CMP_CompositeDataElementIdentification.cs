using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("CMP")]
public class CMP_CompositeDataElementIdentification : EdifactSegment
{
	[Position(1)]
	public string CompositeDataElementTag { get; set; }

	[Position(2)]
	public string ClassDesignatorCoded { get; set; }

	[Position(3)]
	public string MaintenanceOperationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CMP_CompositeDataElementIdentification>(this);
		validator.Required(x=>x.CompositeDataElementTag);
		validator.Length(x => x.CompositeDataElementTag, 1, 4);
		validator.Length(x => x.ClassDesignatorCoded, 1, 3);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		return validator.Results;
	}
}
