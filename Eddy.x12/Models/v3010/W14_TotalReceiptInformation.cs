using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("W14")]
public class W14_TotalReceiptInformation : EdiX12Segment
{
	[Position(01)]
	public decimal? QuantityReceived { get; set; }

	[Position(02)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(03)]
	public decimal? QuantityDamagedOnHold { get; set; }

	[Position(04)]
	public int? LadingQuantityReceived { get; set; }

	[Position(05)]
	public int? LadingQuantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W14_TotalReceiptInformation>(this);
		validator.Required(x=>x.QuantityReceived);
		validator.Length(x => x.QuantityReceived, 1, 7);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.QuantityDamagedOnHold, 1, 9);
		validator.Length(x => x.LadingQuantityReceived, 1, 7);
		validator.Length(x => x.LadingQuantity, 1, 7);
		return validator.Results;
	}
}
