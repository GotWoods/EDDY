using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("E22")]
public class E22_DataElementRelationshipsInASegmentOrComposite : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public string RelationCode { get; set; }

	[Position(03)]
	public int? PositionInSegmentOrComposite { get; set; }

	[Position(04)]
	public int? PositionInSegmentOrComposite2 { get; set; }

	[Position(05)]
	public int? PositionInSegmentOrComposite3 { get; set; }

	[Position(06)]
	public int? PositionInSegmentOrComposite4 { get; set; }

	[Position(07)]
	public int? PositionInSegmentOrComposite5 { get; set; }

	[Position(08)]
	public int? PositionInSegmentOrComposite6 { get; set; }

	[Position(09)]
	public int? PositionInSegmentOrComposite7 { get; set; }

	[Position(10)]
	public int? PositionInSegmentOrComposite8 { get; set; }

	[Position(11)]
	public int? PositionInSegmentOrComposite9 { get; set; }

	[Position(12)]
	public int? PositionInSegmentOrComposite10 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E22_DataElementRelationshipsInASegmentOrComposite>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.RelationCode);
		validator.Required(x=>x.PositionInSegmentOrComposite);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.RelationCode, 1);
		validator.Length(x => x.PositionInSegmentOrComposite, 1, 2);
		validator.Length(x => x.PositionInSegmentOrComposite2, 1, 2);
		validator.Length(x => x.PositionInSegmentOrComposite3, 1, 2);
		validator.Length(x => x.PositionInSegmentOrComposite4, 1, 2);
		validator.Length(x => x.PositionInSegmentOrComposite5, 1, 2);
		validator.Length(x => x.PositionInSegmentOrComposite6, 1, 2);
		validator.Length(x => x.PositionInSegmentOrComposite7, 1, 2);
		validator.Length(x => x.PositionInSegmentOrComposite8, 1, 2);
		validator.Length(x => x.PositionInSegmentOrComposite9, 1, 2);
		validator.Length(x => x.PositionInSegmentOrComposite10, 1, 2);
		return validator.Results;
	}
}
