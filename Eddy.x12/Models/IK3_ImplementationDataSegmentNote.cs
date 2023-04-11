using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("IK3")]
public class IK3_ImplementationDataSegmentNote : EdiX12Segment
{
	[Position(01)]
	public string SegmentIDCode { get; set; }

	[Position(02)]
	public int? SegmentPositionInTransactionSet { get; set; }

	[Position(03)]
	public string LoopIdentifierCode { get; set; }

	[Position(04)]
	public string ImplementationSegmentSyntaxErrorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IK3_ImplementationDataSegmentNote>(this);
		validator.Required(x=>x.SegmentIDCode);
		validator.Required(x=>x.SegmentPositionInTransactionSet);
		validator.Length(x => x.SegmentIDCode, 2, 3);
		validator.Length(x => x.SegmentPositionInTransactionSet, 1, 10);
		validator.Length(x => x.LoopIdentifierCode, 1, 6);
		validator.Length(x => x.ImplementationSegmentSyntaxErrorCode, 1, 3);
		return validator.Results;
	}
}
