using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("BA")]
public class BA_BeginningSegmentForAdvanceConsist : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(02)]
	public string StandardPointLocationCode { get; set; }

	[Position(03)]
	public string EstimatedInterchangeDate { get; set; }

	[Position(04)]
	public string EstimatedInterchangeTime { get; set; }

	[Position(05)]
	public string InterchangeTrainIdentification { get; set; }

	[Position(06)]
	public string StandardPointLocationCode2 { get; set; }

	[Position(07)]
	public string EventDate { get; set; }

	[Position(08)]
	public string EventTime { get; set; }

	[Position(09)]
	public string TypeOfConsistCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BA_BeginningSegmentForAdvanceConsist>(this);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.InterchangeTrainIdentification);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.EstimatedInterchangeDate, 6);
		validator.Length(x => x.EstimatedInterchangeTime, 4);
		validator.Length(x => x.InterchangeTrainIdentification, 1, 10);
		validator.Length(x => x.StandardPointLocationCode2, 6, 9);
		validator.Length(x => x.EventDate, 6);
		validator.Length(x => x.EventTime, 4);
		validator.Length(x => x.TypeOfConsistCode, 1);
		return validator.Results;
	}
}
