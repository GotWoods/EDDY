using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7020;

[Segment("PR1")]
public class PR1_PriceRequestParameterList1 : EdiX12Segment
{
	[Position(01)]
	public string CommodityCodeQualifier { get; set; }

	[Position(02)]
	public string CommodityCode { get; set; }

	[Position(03)]
	public string CommodityCode2 { get; set; }

	[Position(04)]
	public string LocationQualifier { get; set; }

	[Position(05)]
	public string LocationIdentifier { get; set; }

	[Position(06)]
	public string LocationIdentifier2 { get; set; }

	[Position(07)]
	public string StateOrProvinceCode { get; set; }

	[Position(08)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(09)]
	public string LocationQualifier2 { get; set; }

	[Position(10)]
	public string LocationIdentifier3 { get; set; }

	[Position(11)]
	public string LocationIdentifier4 { get; set; }

	[Position(12)]
	public string StateOrProvinceCode2 { get; set; }

	[Position(13)]
	public string StandardCarrierAlphaCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PR1_PriceRequestParameterList1>(this);
		validator.Required(x=>x.CommodityCodeQualifier);
		validator.Required(x=>x.CommodityCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier, x=>x.LocationIdentifier);
		validator.AtLeastOneIsRequired(x=>x.LocationIdentifier, x=>x.StateOrProvinceCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier2, x=>x.LocationIdentifier3);
		validator.AtLeastOneIsRequired(x=>x.LocationIdentifier3, x=>x.StateOrProvinceCode2);
		validator.Length(x => x.CommodityCodeQualifier, 1, 2);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.CommodityCode2, 1, 30);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.LocationIdentifier2, 1, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.LocationQualifier2, 1, 2);
		validator.Length(x => x.LocationIdentifier3, 1, 30);
		validator.Length(x => x.LocationIdentifier4, 1, 30);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		return validator.Results;
	}
}
