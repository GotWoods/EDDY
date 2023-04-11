using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("FA1")]
public class FA1_TypeOfFinancialAccountingData : EdiX12Segment
{
	[Position(01)]
	public string AgencyQualifierCode { get; set; }

	[Position(02)]
	public string ServicePromotionAllowanceOrChargeCode { get; set; }

	[Position(03)]
	public string AllowanceOrChargeIndicatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FA1_TypeOfFinancialAccountingData>(this);
		validator.Required(x=>x.AgencyQualifierCode);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.ServicePromotionAllowanceOrChargeCode, 4);
		validator.Length(x => x.AllowanceOrChargeIndicatorCode, 1);
		return validator.Results;
	}
}
