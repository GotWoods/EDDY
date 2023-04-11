using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("E20")]
public class E20_SegmentHeaderInformation : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public string SegmentIDCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public int? NoteIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E20_SegmentHeaderInformation>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.SegmentIDCode);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.SegmentIDCode, 2, 3);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.NoteIdentificationNumber, 1, 6);
		return validator.Results;
	}
}
