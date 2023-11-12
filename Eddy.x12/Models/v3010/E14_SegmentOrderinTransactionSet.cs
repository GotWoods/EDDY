using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("E14")]
public class E14_SegmentOrderInTransactionSet : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public int? PositionInSet { get; set; }

	[Position(03)]
	public string SegmentIDCode { get; set; }

	[Position(04)]
	public string RequirementDesignator { get; set; }

	[Position(05)]
	public int? MaximumUse { get; set; }

	[Position(06)]
	public string LoopName { get; set; }

	[Position(07)]
	public int? LoopRepeatCount { get; set; }

	[Position(08)]
	public int? LoopLevelNumber { get; set; }

	[Position(09)]
	public int? NoteIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E14_SegmentOrderInTransactionSet>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.PositionInSet);
		validator.Required(x=>x.SegmentIDCode);
		validator.Required(x=>x.RequirementDesignator);
		validator.Required(x=>x.MaximumUse);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.PositionInSet, 1, 6);
		validator.Length(x => x.SegmentIDCode, 2, 3);
		validator.Length(x => x.RequirementDesignator, 1);
		validator.Length(x => x.MaximumUse, 1, 7);
		validator.Length(x => x.LoopName, 2, 4);
		validator.Length(x => x.LoopRepeatCount, 1, 7);
		validator.Length(x => x.LoopLevelNumber, 1);
		validator.Length(x => x.NoteIdentificationNumber, 1, 6);
		return validator.Results;
	}
}
