using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("PTS")]
public class PTS_PropertyTaxStatus : EdiX12Segment
{
	[Position(01)]
	public string StatusCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string TaxServicePaymentCode { get; set; }

	[Position(04)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(05)]
	public string DateTimePeriod { get; set; }

	[Position(06)]
	public string StatusCode2 { get; set; }

	[Position(07)]
	public string TaxJurisdictionCodeQualifier { get; set; }

	[Position(08)]
	public string TaxJurisdictionCode { get; set; }

	[Position(09)]
	public string Description { get; set; }

	[Position(10)]
	public string TypeOfTaxingAuthorityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PTS_PropertyTaxStatus>(this);
		validator.Required(x=>x.StatusCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TaxJurisdictionCodeQualifier, x=>x.TaxJurisdictionCode);
		validator.AtLeastOneIsRequired(x=>x.TaxJurisdictionCode, x=>x.Description);
		validator.Length(x => x.StatusCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.TaxServicePaymentCode, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.StatusCode2, 2);
		validator.Length(x => x.TaxJurisdictionCodeQualifier, 2);
		validator.Length(x => x.TaxJurisdictionCode, 1, 10);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.TypeOfTaxingAuthorityCode, 2);
		return validator.Results;
	}
}
