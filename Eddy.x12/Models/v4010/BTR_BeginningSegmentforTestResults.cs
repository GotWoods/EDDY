using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("BTR")]
public class BTR_BeginningSegmentForTestResults : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string ReportTypeCode { get; set; }

	[Position(05)]
	public string ReferenceIdentification { get; set; }

	[Position(06)]
	public string ReferenceIdentification2 { get; set; }

	[Position(07)]
	public string SecurityLevelCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BTR_BeginningSegmentForTestResults>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.Date);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.ReportTypeCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.SecurityLevelCode, 2);
		return validator.Results;
	}
}
