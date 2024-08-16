using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Models.D00B;

[Segment("MTD")]
public class MTD_MaintenanceOperationDetails : EdifactSegment
{
	[Position(1)]
	public string ObjectTypeCodeQualifier { get; set; }

	[Position(2)]
	public string MaintenanceOperationCode { get; set; }

	[Position(3)]
	public string MaintenanceOperationOperatorCode { get; set; }

	[Position(4)]
	public string MaintenanceOperationPayerCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MTD_MaintenanceOperationDetails>(this);
		validator.Required(x=>x.ObjectTypeCodeQualifier);
		validator.Length(x => x.ObjectTypeCodeQualifier, 1, 3);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		validator.Length(x => x.MaintenanceOperationOperatorCode, 1, 3);
		validator.Length(x => x.MaintenanceOperationPayerCode, 1, 3);
		return validator.Results;
	}
}
