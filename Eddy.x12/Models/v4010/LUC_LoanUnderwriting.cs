using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("LUC")]
public class LUC_LoanUnderwriting : EdiX12Segment
{
	[Position(01)]
	public string LoanDocumentationTypeCode { get; set; }

	[Position(02)]
	public string LoanPurposeCode { get; set; }

	[Position(03)]
	public C048_CompositeUseOfProceeds CompositeUseOfProceeds { get; set; }

	[Position(04)]
	public string RiskOfLossCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LUC_LoanUnderwriting>(this);
		validator.Required(x=>x.LoanDocumentationTypeCode);
		validator.Required(x=>x.LoanPurposeCode);
		validator.Length(x => x.LoanDocumentationTypeCode, 1);
		validator.Length(x => x.LoanPurposeCode, 2);
		validator.Length(x => x.RiskOfLossCode, 2);
		return validator.Results;
	}
}
