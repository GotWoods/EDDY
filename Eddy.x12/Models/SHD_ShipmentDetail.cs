using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SHD")]
public class SHD_ShipmentDetail : EdiX12Segment
{
	[Position(01)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(02)]
	public decimal? QuantityReceived { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Weight { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(06)]
	public decimal? Volume { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(08)]
	public decimal? OrderSizingFactor { get; set; }

	[Position(09)]
	public string PriceBracketIdentifier { get; set; }

	[Position(10)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(11)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(12)]
	public string ShipmentOrderStatusCode { get; set; }

	[Position(13)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(14)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SHD_ShipmentDetail>(this);
		validator.AtLeastOneIsRequired(x=>x.NumberOfUnitsShipped, x=>x.QuantityReceived);
		validator.ARequiresB(x=>x.NumberOfUnitsShipped, x=>x.UnitOrBasisForMeasurementCode);
		validator.ARequiresB(x=>x.QuantityReceived, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight, x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.UnitOrBasisForMeasurementCode3);
		validator.ARequiresB(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.QuantityReceived, 1, 7);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.OrderSizingFactor, 1, 10);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ShipmentOrderStatusCode, 2);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		return validator.Results;
	}
}
