using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G33")]
public class G33_TotalDollarsSummary : EdiX12Segment
{
	[Position(01)]
	public string TotalInvoiceAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G33_TotalDollarsSummary>(this);
		validator.Required(x=>x.TotalInvoiceAmount);
		validator.Length(x => x.TotalInvoiceAmount, 1, 10);
		return validator.Results;
	}
}
