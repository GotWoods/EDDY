using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("INQ")]
public class INQ_CreditInquiryDetails : EdiX12Segment
{
	[Position(01)]
	public string ResultsCode { get; set; }

	[Position(02)]
	public string TypeOfAccountCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<INQ_CreditInquiryDetails>(this);
		validator.Required(x=>x.ResultsCode);
		validator.Length(x => x.ResultsCode, 1, 2);
		validator.Length(x => x.TypeOfAccountCode, 2);
		return validator.Results;
	}
}
