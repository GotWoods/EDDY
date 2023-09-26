using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("FA2")]
public class FA2_AccountingData : EdiX12Segment
{
	[Position(01)]
	public string BreakdownStructureDetailCode { get; set; }

	[Position(02)]
	public string FinancialInformationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FA2_AccountingData>(this);
		validator.Required(x=>x.BreakdownStructureDetailCode);
		validator.Required(x=>x.FinancialInformationCode);
		validator.Length(x => x.BreakdownStructureDetailCode, 2);
		validator.Length(x => x.FinancialInformationCode, 1, 80);
		return validator.Results;
	}
}
