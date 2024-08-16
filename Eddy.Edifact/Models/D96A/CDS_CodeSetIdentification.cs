using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("CDS")]
public class CDS_CodeSetIdentification : EdifactSegment
{
	[Position(1)]
	public C702_CodeSetIdentification CodeSetIdentification { get; set; }

	[Position(2)]
	public string ClassDesignatorCoded { get; set; }

	[Position(3)]
	public string MaintenanceOperationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CDS_CodeSetIdentification>(this);
		validator.Required(x=>x.CodeSetIdentification);
		validator.Length(x => x.ClassDesignatorCoded, 1, 3);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		return validator.Results;
	}
}