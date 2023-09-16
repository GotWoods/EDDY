using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("TD1")]
public class TD1_CarrierDetailsQuantityAndWeight : EdiX12Segment
{
	[Position(01)]
	public string PackagingCode { get; set; }

	[Position(02)]
	public int? LadingQuantity { get; set; }

	[Position(03)]
	public string CommodityCodeQualifier { get; set; }

	[Position(04)]
	public string CommodityCode { get; set; }

	[Position(05)]
	public string LadingDescription { get; set; }

	[Position(06)]
	public string WeightQualifier { get; set; }

	[Position(07)]
	public decimal? Weight { get; set; }

	[Position(08)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TD1_CarrierDetailsQuantityAndWeight>(this);
		validator.ARequiresB(x=>x.PackagingCode, x=>x.LadingQuantity);
		validator.ARequiresB(x=>x.CommodityCodeQualifier, x=>x.CommodityCode);
		validator.ARequiresB(x=>x.WeightQualifier, x=>x.Weight);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight, x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.PackagingCode, 3, 5);
		validator.Length(x => x.LadingQuantity, 1, 7);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.LadingDescription, 1, 50);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}
