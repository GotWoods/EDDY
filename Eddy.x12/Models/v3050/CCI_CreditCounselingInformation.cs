using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("CCI")]
public class CCI_CreditCounselingInformation : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCode { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(04)]
	public string ReferenceNumber2 { get; set; }

	[Position(05)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(06)]
	public string DateTimePeriod { get; set; }

	[Position(07)]
	public string DateTimePeriod2 { get; set; }

	[Position(08)]
	public string DateTimePeriod3 { get; set; }

	[Position(09)]
	public decimal? MonetaryAmount { get; set; }

	[Position(10)]
	public string CounselingStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CCI_CreditCounselingInformation>(this);
		validator.Required(x=>x.IdentificationCode);
		validator.Required(x=>x.ReferenceNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.CounselingStatusCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod, x=>x.DateTimePeriod2, x=>x.DateTimePeriod3);
		validator.ARequiresB(x=>x.DateTimePeriod, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod2, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod3, x=>x.DateTimePeriodFormatQualifier);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.DateTimePeriod3, 1, 35);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.CounselingStatusCode, 1);
		return validator.Results;
	}
}
