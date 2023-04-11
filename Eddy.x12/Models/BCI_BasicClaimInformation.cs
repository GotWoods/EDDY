using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("BCI")]
public class BCI_BasicClaimInformation : EdiX12Segment 
{
	[Position(01)]
	public string IndustryCode { get; set; }

	[Position(02)]
	public string InsuranceTypeCode { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string StateOrProvinceCode { get; set; }

	[Position(05)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(06)]
	public string DateTimePeriod { get; set; }

	[Position(07)]
	public string ReportTypeCode { get; set; }

	[Position(08)]
	public string CurrencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BCI_BasicClaimInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.InsuranceTypeCode, 1, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.ReportTypeCode, 2);
		validator.Length(x => x.CurrencyCode, 3);
		return validator.Results;
	}
}
