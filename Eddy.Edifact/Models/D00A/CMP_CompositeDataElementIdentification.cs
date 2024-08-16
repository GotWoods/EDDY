using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("CMP")]
public class CMP_CompositeDataElementIdentification : EdifactSegment
{
	[Position(1)]
	public string CompositeDataElementTagIdentifier { get; set; }

	[Position(2)]
	public string DesignatedClassCode { get; set; }

	[Position(3)]
	public string MaintenanceOperationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CMP_CompositeDataElementIdentification>(this);
		validator.Required(x=>x.CompositeDataElementTagIdentifier);
		validator.Length(x => x.CompositeDataElementTagIdentifier, 1, 4);
		validator.Length(x => x.DesignatedClassCode, 1, 3);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		return validator.Results;
	}
}
