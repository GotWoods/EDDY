using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("FA1")]
public class FA1_TypeOfFinancialAccountingData : EdiX12Segment
{
	[Position(01)]
	public string AgencyQualifierCode { get; set; }

	[Position(02)]
	public string ServicePromotionAllowanceOrChargeCode { get; set; }

	[Position(03)]
	public string AllowanceOrChargeIndicator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FA1_TypeOfFinancialAccountingData>(this);
		validator.Required(x=>x.AgencyQualifierCode);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.ServicePromotionAllowanceOrChargeCode, 4);
		validator.Length(x => x.AllowanceOrChargeIndicator, 1);
		return validator.Results;
	}
}
