using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("W10")]
public class W10_WarehouseAdditionalCarrierInformation : EdiX12Segment
{
	[Position(01)]
	public string UnitLoadOptionCode { get; set; }

	[Position(02)]
	public int? QuantityOfPalletsShipped { get; set; }

	[Position(03)]
	public string PalletExchangeCode { get; set; }

	[Position(04)]
	public string SealNumber { get; set; }

	[Position(05)]
	public string SealNumber2 { get; set; }

	[Position(06)]
	public int? Temperature { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(08)]
	public int? Temperature2 { get; set; }

	[Position(09)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W10_WarehouseAdditionalCarrierInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Temperature, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Temperature2, x=>x.UnitOrBasisForMeasurementCode2);
		validator.Length(x => x.UnitLoadOptionCode, 2);
		validator.Length(x => x.QuantityOfPalletsShipped, 1, 3);
		validator.Length(x => x.PalletExchangeCode, 1);
		validator.Length(x => x.SealNumber, 2, 15);
		validator.Length(x => x.SealNumber2, 2, 15);
		validator.Length(x => x.Temperature, 1, 3);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Temperature2, 1, 3);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		return validator.Results;
	}
}
