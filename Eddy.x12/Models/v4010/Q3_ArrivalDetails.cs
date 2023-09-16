using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("Q3")]
public class Q3_ArrivalDetails : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string ShipmentMethodOfPayment { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<Q3_ArrivalDetails>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.ShipmentMethodOfPayment);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ShipmentMethodOfPayment, 2);
		return validator.Results;
	}
}
