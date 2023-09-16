using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("Q3")]
public class Q3_ArrivalDetails : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string ShipmentMethodOfPaymentCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Q3_ArrivalDetails>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.ShipmentMethodOfPaymentCode);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
		return validator.Results;
	}
}
