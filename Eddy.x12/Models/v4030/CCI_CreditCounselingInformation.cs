using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("CCI")]
public class CCI_CreditCounselingInformation : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(04)]
	public string ReferenceIdentification2 { get; set; }

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
		validator.Required(x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.CounselingStatusCode);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod, x=>x.DateTimePeriod2, x=>x.DateTimePeriod3);
		validator.ARequiresB(x=>x.DateTimePeriod, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod2, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod3, x=>x.DateTimePeriodFormatQualifier);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.DateTimePeriod3, 1, 35);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.CounselingStatusCode, 1);
		return validator.Results;
	}
}
