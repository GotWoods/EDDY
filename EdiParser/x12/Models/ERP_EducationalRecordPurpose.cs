using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("ERP")]
public class ERP_EducationalRecordPurpose : EdiX12Segment
{
	[Position(01)]
	public string TransactionTypeCode { get; set; }

	[Position(02)]
	public string StatusReasonCode { get; set; }

	[Position(03)]
	public string ActionCode { get; set; }

	[Position(04)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(05)]
	public string DateTimePeriod { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ERP_EducationalRecordPurpose>(this);
		validator.Required(x=>x.TransactionTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		return validator.Results;
	}
}
