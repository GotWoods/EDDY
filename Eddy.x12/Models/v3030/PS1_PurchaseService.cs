using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("PS1")]
public class PS1_PurchaseService : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumber { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string StateOrProvinceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PS1_PurchaseService>(this);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.StateOrProvinceCode, 2);
		return validator.Results;
	}
}
