using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("SHD")]
public class SHD_ShipmentDetail : EdiX12Segment
{
	[Position(01)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(02)]
	public decimal? QuantityReceived { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Weight { get; set; }

	[Position(05)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(06)]
	public decimal? Volume { get; set; }

	[Position(07)]
	public string UnitOfMeasurementCode3 { get; set; }

	[Position(08)]
	public decimal? EquivalentWeight { get; set; }

	[Position(09)]
	public string PriceBracketIdentifier { get; set; }

	[Position(10)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(11)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(12)]
	public string ShipmentOrderStatusCode { get; set; }

	[Position(13)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(14)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SHD_ShipmentDetail>(this);
		validator.AtLeastOneIsRequired(x=>x.NumberOfUnitsShipped, x=>x.QuantityReceived);
		validator.ARequiresB(x=>x.NumberOfUnitsShipped, x=>x.UnitOfMeasurementCode);
		validator.ARequiresB(x=>x.QuantityReceived, x=>x.UnitOfMeasurementCode);
		validator.ARequiresB(x=>x.Weight, x=>x.UnitOfMeasurementCode2);
		validator.ARequiresB(x=>x.Volume, x=>x.UnitOfMeasurementCode3);
		validator.ARequiresB(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.QuantityReceived, 1, 7);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode3, 2);
		validator.Length(x => x.EquivalentWeight, 1, 10);
		validator.Length(x => x.PriceBracketIdentifier, 1, 3);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ShipmentOrderStatusCode, 2);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
