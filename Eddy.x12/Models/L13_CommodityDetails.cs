using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("L13")]
public class L13_CommodityDetails : EdiX12Segment
{
	[Position(01)]
	public string CommodityCodeQualifier { get; set; }

	[Position(02)]
	public string CommodityCode { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string AmountQualifierCode { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount { get; set; }

	[Position(07)]
	public int? AssignedNumber { get; set; }

	[Position(08)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(09)]
	public decimal? Quantity2 { get; set; }

	[Position(10)]
	public string WeightUnitCode { get; set; }

	[Position(11)]
	public decimal? Weight { get; set; }

	[Position(12)]
	public string FreeFormDescription { get; set; }

	[Position(13)]
	public string ExportExceptionCode { get; set; }

	[Position(14)]
	public string ActionCode { get; set; }

	[Position(15)]
	public string HarborMaintenanceFeeHMFExemptionCode { get; set; }

	[Position(16)]
	public string Amount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L13_CommodityDetails>(this);
		validator.Required(x=>x.CommodityCodeQualifier);
		validator.Required(x=>x.CommodityCode);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.AmountQualifierCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.AssignedNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode2, x=>x.Quantity2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitCode, x=>x.Weight);
		validator.IfOneIsFilled_AllAreRequired(x=>x.HarborMaintenanceFeeHMFExemptionCode, x=>x.Amount);
		validator.Length(x => x.CommodityCodeQualifier, 1, 2);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.AssignedNumber, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.ExportExceptionCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.HarborMaintenanceFeeHMFExemptionCode, 1, 2);
		validator.Length(x => x.Amount, 1, 15);
		return validator.Results;
	}
}
