using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("BAX")]
public class BAX_BeginningSegmentForAdvanceConsist : EdiX12Segment
{
	[Position(01)]
	public string StandardPointLocationCode { get; set; }

	[Position(02)]
	public string TypeOfConsistCode { get; set; }

	[Position(03)]
	public string DateTimeQualifier { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Time { get; set; }

	[Position(06)]
	public string InterchangeTrainIdentification { get; set; }

	[Position(07)]
	public string StandardPointLocationCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BAX_BeginningSegmentForAdvanceConsist>(this);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.TypeOfConsistCode);
		validator.Required(x=>x.DateTimeQualifier);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Time);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.TypeOfConsistCode, 1);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 6);
		validator.Length(x => x.InterchangeTrainIdentification, 1, 10);
		validator.Length(x => x.StandardPointLocationCode2, 6, 9);
		return validator.Results;
	}
}
