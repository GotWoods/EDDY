using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v8030;

[Segment("N10")]
public class N10_QuantityAndDescription : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string FreeFormDescription { get; set; }

	[Position(03)]
	public string MarksAndNumbers { get; set; }

	[Position(04)]
	public string CommodityCodeQualifier { get; set; }

	[Position(05)]
	public string CommodityCode { get; set; }

	[Position(06)]
	public int? CustomsShipmentValue { get; set; }

	[Position(07)]
	public string WeightUnitCode { get; set; }

	[Position(08)]
	public decimal? Weight { get; set; }

	[Position(09)]
	public string ReferenceIdentification { get; set; }

	[Position(10)]
	public string ManifestUnitCode { get; set; }

	[Position(11)]
	public string CountryCode { get; set; }

	[Position(12)]
	public string CountryCode2 { get; set; }

	[Position(13)]
	public string CurrencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N10_QuantityAndDescription>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CommodityCodeQualifier, x=>x.CommodityCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitCode, x=>x.Weight);
		validator.ARequiresB(x=>x.CurrencyCode, x=>x.CustomsShipmentValue);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.MarksAndNumbers, 1, 80);
		validator.Length(x => x.CommodityCodeQualifier, 1, 2);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.CustomsShipmentValue, 2, 9);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ManifestUnitCode, 1, 3);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.CountryCode2, 2, 3);
		validator.Length(x => x.CurrencyCode, 3);
		return validator.Results;
	}
}
