using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G66")]
public class G66_TransportationInstructions : EdiX12Segment
{
	[Position(01)]
	public string ShipmentMethodOfPaymentCode { get; set; }

	[Position(02)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(03)]
	public string PalletExchangeCode { get; set; }

	[Position(04)]
	public string UnitLoadOptionCode { get; set; }

	[Position(05)]
	public string Routing { get; set; }

	[Position(06)]
	public string FOBPointCode { get; set; }

	[Position(07)]
	public string FOBPoint { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G66_TransportationInstructions>(this);
		validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.PalletExchangeCode, 1);
		validator.Length(x => x.UnitLoadOptionCode, 2);
		validator.Length(x => x.Routing, 1, 35);
		validator.Length(x => x.FOBPointCode, 2);
		validator.Length(x => x.FOBPoint, 1, 30);
		return validator.Results;
	}
}
