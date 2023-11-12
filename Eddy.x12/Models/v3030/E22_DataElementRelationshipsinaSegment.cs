using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("E22")]
public class E22_DataElementRelationshipsInASegment : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceOperationCode { get; set; }

	[Position(02)]
	public string RelationCode { get; set; }

	[Position(03)]
	public int? PositionInSegment { get; set; }

	[Position(04)]
	public int? PositionInSegment2 { get; set; }

	[Position(05)]
	public int? PositionInSegment3 { get; set; }

	[Position(06)]
	public int? PositionInSegment4 { get; set; }

	[Position(07)]
	public int? PositionInSegment5 { get; set; }

	[Position(08)]
	public int? PositionInSegment6 { get; set; }

	[Position(09)]
	public int? PositionInSegment7 { get; set; }

	[Position(10)]
	public int? PositionInSegment8 { get; set; }

	[Position(11)]
	public int? PositionInSegment9 { get; set; }

	[Position(12)]
	public int? PositionInSegment10 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E22_DataElementRelationshipsInASegment>(this);
		validator.Required(x=>x.MaintenanceOperationCode);
		validator.Required(x=>x.RelationCode);
		validator.Required(x=>x.PositionInSegment);
		validator.Length(x => x.MaintenanceOperationCode, 1);
		validator.Length(x => x.RelationCode, 1);
		validator.Length(x => x.PositionInSegment, 1, 2);
		validator.Length(x => x.PositionInSegment2, 1, 2);
		validator.Length(x => x.PositionInSegment3, 1, 2);
		validator.Length(x => x.PositionInSegment4, 1, 2);
		validator.Length(x => x.PositionInSegment5, 1, 2);
		validator.Length(x => x.PositionInSegment6, 1, 2);
		validator.Length(x => x.PositionInSegment7, 1, 2);
		validator.Length(x => x.PositionInSegment8, 1, 2);
		validator.Length(x => x.PositionInSegment9, 1, 2);
		validator.Length(x => x.PositionInSegment10, 1, 2);
		return validator.Results;
	}
}
