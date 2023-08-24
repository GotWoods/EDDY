using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("AK3")]
public class AK3_DataSegmentNote : EdiX12Segment
{
	[Position(01)]
	public string SegmentIDCode { get; set; }

	[Position(02)]
	public int? SegmentPositionInTransactionSet { get; set; }

	[Position(03)]
	public string LoopIdentifierCode { get; set; }

	[Position(04)]
	public string SegmentSyntaxErrorCode { get; set; }

	[Position(05)]
	public string SegmentSyntaxErrorCode2 { get; set; }

	[Position(06)]
	public string SegmentSyntaxErrorCode3 { get; set; }

	[Position(07)]
	public string SegmentSyntaxErrorCode4 { get; set; }

	[Position(08)]
	public string SegmentSyntaxErrorCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AK3_DataSegmentNote>(this);
		validator.Required(x=>x.SegmentIDCode);
		validator.Required(x=>x.SegmentPositionInTransactionSet);
		validator.Length(x => x.SegmentIDCode, 2, 3);
		validator.Length(x => x.SegmentPositionInTransactionSet, 1, 6);
		validator.Length(x => x.LoopIdentifierCode, 1, 4);
		validator.Length(x => x.SegmentSyntaxErrorCode, 1, 3);
		validator.Length(x => x.SegmentSyntaxErrorCode2, 1, 3);
		validator.Length(x => x.SegmentSyntaxErrorCode3, 1, 3);
		validator.Length(x => x.SegmentSyntaxErrorCode4, 1, 3);
		validator.Length(x => x.SegmentSyntaxErrorCode5, 1, 3);
		return validator.Results;
	}
}
