using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("E13")]
public class E13_SegmentOrderInTransactionSet : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public int? PositionInSet { get; set; }

	[Position(03)]
	public string SectionDesignatorCode { get; set; }

	[Position(04)]
	public string SegmentIDCode { get; set; }

	[Position(05)]
	public string RequirementDesignatorCode { get; set; }

	[Position(06)]
	public int? MaximumUse { get; set; }

	[Position(07)]
	public string LoopName { get; set; }

	[Position(08)]
	public int? LoopRepeatCount { get; set; }

	[Position(09)]
	public int? LoopLevelNumber { get; set; }

	[Position(10)]
	public int? NoteIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E13_SegmentOrderInTransactionSet>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.PositionInSet);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.PositionInSet, 1, 6);
		validator.Length(x => x.SectionDesignatorCode, 1);
		validator.Length(x => x.SegmentIDCode, 2, 3);
		validator.Length(x => x.RequirementDesignatorCode, 1);
		validator.Length(x => x.MaximumUse, 1, 7);
		validator.Length(x => x.LoopName, 2, 4);
		validator.Length(x => x.LoopRepeatCount, 1, 7);
		validator.Length(x => x.LoopLevelNumber, 1);
		validator.Length(x => x.NoteIdentificationNumber, 1, 6);
		return validator.Results;
	}
}
