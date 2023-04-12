using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("W14")]
public class W14_TotalReceiptInformation : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public decimal? Quantity2 { get; set; }

	[Position(03)]
	public decimal? Quantity3 { get; set; }

	[Position(04)]
	public decimal? Quantity4 { get; set; }

	[Position(05)]
	public decimal? Quantity5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W14_TotalReceiptInformation>(this);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.Quantity4, 1, 15);
		validator.Length(x => x.Quantity5, 1, 15);
		return validator.Results;
	}
}
