using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4050;

[Segment("TED")]
public class TED_TechnicalErrorDescription : EdiX12Segment
{
	[Position(01)]
	public string ApplicationErrorConditionCode { get; set; }

	[Position(02)]
	public string FreeFormMessage { get; set; }

	[Position(03)]
	public string SegmentIDCode { get; set; }

	[Position(04)]
	public int? SegmentPositionInTransactionSet { get; set; }

	[Position(05)]
	public C030_PositionInSegment PositionInSegment { get; set; }

	[Position(06)]
	public C999_ReferenceInSegment ReferenceInSegment { get; set; }

	[Position(07)]
	public string CopyOfBadDataElement { get; set; }

	[Position(08)]
	public string DataElementNewContent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TED_TechnicalErrorDescription>(this);
		validator.Required(x=>x.ApplicationErrorConditionCode);
		validator.Length(x => x.ApplicationErrorConditionCode, 1, 3);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		validator.Length(x => x.SegmentIDCode, 2, 3);
		validator.Length(x => x.SegmentPositionInTransactionSet, 1, 6);
		validator.Length(x => x.CopyOfBadDataElement, 1, 99);
		validator.Length(x => x.DataElementNewContent, 1, 99);
		return validator.Results;
	}
}
