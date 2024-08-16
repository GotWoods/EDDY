using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("CDS")]
public class CDS_CodeSetIdentification : EdifactSegment
{
	[Position(1)]
	public C702_CodeSetIdentification CodeSetIdentification { get; set; }

	[Position(2)]
	public string DesignatedClassCode { get; set; }

	[Position(3)]
	public string MaintenanceOperationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CDS_CodeSetIdentification>(this);
		validator.Required(x=>x.CodeSetIdentification);
		validator.Length(x => x.DesignatedClassCode, 1, 3);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		return validator.Results;
	}
}
