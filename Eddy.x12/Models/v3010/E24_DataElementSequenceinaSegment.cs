using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("E24")]
public class E24_DataElementSequenceInASegment : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public int? PositionInSegment { get; set; }

	[Position(03)]
	public int? DataElementReferenceNumber { get; set; }

	[Position(04)]
	public string RequirementDesignator { get; set; }

	[Position(05)]
	public string DataElementType { get; set; }

	[Position(06)]
	public int? NoteIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E24_DataElementSequenceInASegment>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.PositionInSegment);
		validator.Required(x=>x.DataElementReferenceNumber);
		validator.Required(x=>x.RequirementDesignator);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.PositionInSegment, 1, 2);
		validator.Length(x => x.DataElementReferenceNumber, 1, 4);
		validator.Length(x => x.RequirementDesignator, 1);
		validator.Length(x => x.DataElementType, 1);
		validator.Length(x => x.NoteIdentificationNumber, 1, 6);
		return validator.Results;
	}
}
