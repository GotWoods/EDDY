using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G39")]
public class G39_ItemCharacteristicsVendorsSellingUnit : EdiX12Segment
{
	[Position(01)]
	public string UPCCaseCode { get; set; }

	[Position(02)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(03)]
	public string ProductServiceID { get; set; }

	[Position(04)]
	public string SpecialHandlingCode { get; set; }

	[Position(05)]
	public decimal? UnitWeight { get; set; }

	[Position(06)]
	public string WeightQualifier { get; set; }

	[Position(07)]
	public string WeightUnitQualifier { get; set; }

	[Position(08)]
	public decimal? Height { get; set; }

	[Position(09)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(10)]
	public decimal? Width { get; set; }

	[Position(11)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(12)]
	public decimal? Length { get; set; }

	[Position(13)]
	public string UnitOfMeasurementCode3 { get; set; }

	[Position(14)]
	public decimal? Volume { get; set; }

	[Position(15)]
	public string UnitOfMeasurementCode4 { get; set; }

	[Position(16)]
	public int? PalletBlockAndTiers { get; set; }

	[Position(17)]
	public int? Pack { get; set; }

	[Position(18)]
	public decimal? Size { get; set; }

	[Position(19)]
	public string UnitOfMeasurementCode5 { get; set; }

	[Position(20)]
	public string Color { get; set; }

	[Position(21)]
	public string ShipmentIdentification { get; set; }

	[Position(22)]
	public string AlternateTiersPerPallet { get; set; }

	[Position(23)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(24)]
	public string ProductServiceID2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G39_ItemCharacteristicsVendorsSellingUnit>(this);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.SpecialHandlingCode, 2, 3);
		validator.Length(x => x.UnitWeight, 1, 8);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitQualifier, 1);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode3, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode4, 2);
		validator.Length(x => x.PalletBlockAndTiers, 6);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.Size, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode5, 2);
		validator.Length(x => x.Color, 1, 10);
		validator.Length(x => x.ShipmentIdentification, 2, 30);
		validator.Length(x => x.AlternateTiersPerPallet, 1, 3);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 30);
		return validator.Results;
	}
}
