using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("CB1")]
public class CB1_ContractAndCostAccountingStandardsData : EdiX12Segment
{
	[Position(01)]
	public string AcquisitionDataCode { get; set; }

	[Position(02)]
	public string FinancingTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CB1_ContractAndCostAccountingStandardsData>(this);
		validator.Required(x=>x.AcquisitionDataCode);
		validator.Length(x => x.AcquisitionDataCode, 2);
		validator.Length(x => x.FinancingTypeCode, 1);
		return validator.Results;
	}
}
