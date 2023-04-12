using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("TA")]
public class TA_TaxAuthority : EdiX12Segment
{
	[Position(01)]
	public string TaxJurisdictionCodeQualifier { get; set; }

	[Position(02)]
	public string TaxJurisdictionCode { get; set; }

	[Position(03)]
	public string Description { get; set; }

	[Position(04)]
	public string TypeOfTaxingAuthorityCode { get; set; }

	[Position(05)]
	public string Description2 { get; set; }

	[Position(06)]
	public string TaxServicePaymentCode { get; set; }

	[Position(07)]
	public string StatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TA_TaxAuthority>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TaxJurisdictionCodeQualifier, x=>x.TaxJurisdictionCode);
		validator.AtLeastOneIsRequired(x=>x.TaxJurisdictionCode, x=>x.Description);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TypeOfTaxingAuthorityCode, x=>x.Description2);
		validator.Length(x => x.TaxJurisdictionCodeQualifier, 2);
		validator.Length(x => x.TaxJurisdictionCode, 1, 10);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.TypeOfTaxingAuthorityCode, 2);
		validator.Length(x => x.Description2, 1, 80);
		validator.Length(x => x.TaxServicePaymentCode, 1);
		validator.Length(x => x.StatusCode, 2);
		return validator.Results;
	}
}
