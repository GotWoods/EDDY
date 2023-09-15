using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("CSH")]
public class CSH_HeaderSaleCondition : EdiX12Segment
{
	[Position(01)]
	public string SalesRequirementCode { get; set; }

	[Position(02)]
	public string DoNotExceedActionCode { get; set; }

	[Position(03)]
	public string DoNotExceedAmount { get; set; }

	[Position(04)]
	public string AccountNumber { get; set; }

	[Position(05)]
	public string RequiredInvoiceDate { get; set; }

	[Position(06)]
	public string AgencyQualifierCode { get; set; }

	[Position(07)]
	public string SpecialServicesCode { get; set; }

	[Position(08)]
	public string ProductServiceSubstitutionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CSH_HeaderSaleCondition>(this);
		validator.ARequiresB(x=>x.DoNotExceedActionCode, x=>x.DoNotExceedAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AgencyQualifierCode, x=>x.SpecialServicesCode);
		validator.Length(x => x.SalesRequirementCode, 1, 2);
		validator.Length(x => x.DoNotExceedActionCode, 1);
		validator.Length(x => x.DoNotExceedAmount, 2, 9);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.RequiredInvoiceDate, 6);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.SpecialServicesCode, 2, 10);
		validator.Length(x => x.ProductServiceSubstitutionCode, 1, 2);
		return validator.Results;
	}
}
