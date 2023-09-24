using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("W08")]
public class W08_ReceiptCarrierInformation : EdiX12Segment
{
	[Position(01)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string Routing { get; set; }

	[Position(04)]
	public string EquipmentInitial { get; set; }

	[Position(05)]
	public string EquipmentNumber { get; set; }

	[Position(06)]
	public string SealNumber { get; set; }

	[Position(07)]
	public string SealNumber2 { get; set; }

	[Position(08)]
	public string SealStatusCode { get; set; }

	[Position(09)]
	public string UnitLoadOptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W08_ReceiptCarrierInformation>(this);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.AtLeastOneIsRequired(x=>x.StandardCarrierAlphaCode, x=>x.EquipmentInitial);
		validator.IfOneIsFilled_AllAreRequired(x=>x.EquipmentInitial, x=>x.EquipmentNumber);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Routing, 1, 35);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.SealNumber, 2, 15);
		validator.Length(x => x.SealNumber2, 2, 15);
		validator.Length(x => x.SealStatusCode, 2);
		validator.Length(x => x.UnitLoadOptionCode, 2);
		return validator.Results;
	}
}
