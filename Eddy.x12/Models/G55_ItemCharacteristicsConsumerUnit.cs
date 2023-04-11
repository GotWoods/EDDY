using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G55")]
public class G55_ItemCharacteristicsConsumerUnit : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(02)]
	public string ProductServiceID { get; set; }

	[Position(03)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(04)]
	public string ProductServiceID2 { get; set; }

	[Position(05)]
	public decimal? Height { get; set; }

	[Position(06)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(07)]
	public decimal? Width { get; set; }

	[Position(08)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(09)]
	public decimal? Length { get; set; }

	[Position(10)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(11)]
	public decimal? Volume { get; set; }

	[Position(12)]
	public string UnitOrBasisForMeasurementCode4 { get; set; }

	[Position(13)]
	public int? Pack { get; set; }

	[Position(14)]
	public decimal? Size { get; set; }

	[Position(15)]
	public string UnitOrBasisForMeasurementCode5 { get; set; }

	[Position(16)]
	public string CashRegisterItemDescription { get; set; }

	[Position(17)]
	public string CashRegisterItemDescription2 { get; set; }

	[Position(18)]
	public string CouponFamilyCode { get; set; }

	[Position(19)]
	public int? DatedProductNumberOfDays { get; set; }

	[Position(20)]
	public decimal? DepositValue { get; set; }

	[Position(21)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(22)]
	public string Color { get; set; }

	[Position(23)]
	public decimal? UnitWeight { get; set; }

	[Position(24)]
	public string WeightQualifier { get; set; }

	[Position(25)]
	public string WeightUnitCode { get; set; }

	[Position(26)]
	public decimal? UnitWeight2 { get; set; }

	[Position(27)]
	public string WeightQualifier2 { get; set; }

	[Position(28)]
	public string WeightUnitCode2 { get; set; }

	[Position(29)]
	public string ProductServiceIDQualifier3 { get; set; }

	[Position(30)]
	public string ProductServiceID3 { get; set; }

	[Position(31)]
	public string FreeFormDescription { get; set; }

	[Position(32)]
	public int? InnerPack { get; set; }

	[Position(33)]
	public string PackagingCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G55_ItemCharacteristicsConsumerUnit>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Height, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Width, x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Length, x=>x.UnitOrBasisForMeasurementCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.UnitOrBasisForMeasurementCode4);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Size, x=>x.UnitOrBasisForMeasurementCode5);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier3, x=>x.ProductServiceID3);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 80);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode4, 2);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.Size, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode5, 2);
		validator.Length(x => x.CashRegisterItemDescription, 1, 20);
		validator.Length(x => x.CashRegisterItemDescription2, 1, 20);
		validator.Length(x => x.CouponFamilyCode, 3);
		validator.Length(x => x.DatedProductNumberOfDays, 1, 4);
		validator.Length(x => x.DepositValue, 1, 8);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Color, 1, 10);
		validator.Length(x => x.UnitWeight, 1, 8);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.UnitWeight2, 1, 8);
		validator.Length(x => x.WeightQualifier2, 1, 2);
		validator.Length(x => x.WeightUnitCode2, 1);
		validator.Length(x => x.ProductServiceIDQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 80);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.InnerPack, 1, 6);
		validator.Length(x => x.PackagingCode, 3, 5);
		return validator.Results;
	}
}
