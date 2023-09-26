using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("SSC")]
public class SSC_BeginningSegmentForServiceCommitmentAdvice : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string IdentificationCode { get; set; }

	[Position(06)]
	public string ServiceCommitmentTypeCode { get; set; }

	[Position(07)]
	public string LoadEmptyStatusCode { get; set; }

	[Position(08)]
	public int? PercentIntegerFormat { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SSC_BeginningSegmentForServiceCommitmentAdvice>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.DateTimePeriodFormatQualifier);
		validator.Required(x=>x.DateTimePeriod);
		validator.Required(x=>x.IdentificationCode);
		validator.Required(x=>x.ServiceCommitmentTypeCode);
		validator.Required(x=>x.LoadEmptyStatusCode);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.ServiceCommitmentTypeCode, 1);
		validator.Length(x => x.LoadEmptyStatusCode, 1);
		validator.Length(x => x.PercentIntegerFormat, 1, 3);
		return validator.Results;
	}
}
