using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("AC")]
public class AC_MovementRateSetHeader : EdiX12Segment
{
	[Position(01)]
	public string CommodityCodeQualifier { get; set; }

	[Position(02)]
	public string CommodityCode { get; set; }

	[Position(03)]
	public string RateRequestResponseCode { get; set; }

	[Position(04)]
	public string ConveyanceCode { get; set; }

	[Position(05)]
	public string LocationQualifier { get; set; }

	[Position(06)]
	public string LocationQualifier2 { get; set; }

	[Position(07)]
	public string StateOrProvinceCode { get; set; }

	[Position(08)]
	public string LocationIdentifier { get; set; }

	[Position(09)]
	public string StateOrProvinceCode2 { get; set; }

	[Position(10)]
	public string LocationIdentifier2 { get; set; }

	[Position(11)]
	public string ConditionCode { get; set; }

	[Position(12)]
	public string ConditionValue { get; set; }

	[Position(13)]
	public string Date { get; set; }

	[Position(14)]
	public string Date2 { get; set; }

	[Position(15)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(16)]
	public string StandardCarrierAlphaCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AC_MovementRateSetHeader>(this);
		validator.Required(x=>x.CommodityCodeQualifier);
		validator.Required(x=>x.CommodityCode);
		validator.Required(x=>x.RateRequestResponseCode);
		validator.Required(x=>x.ConveyanceCode);
		validator.Required(x=>x.LocationQualifier);
		validator.Required(x=>x.LocationQualifier2);
		validator.Length(x => x.CommodityCodeQualifier, 1);
		validator.Length(x => x.CommodityCode, 1, 16);
		validator.Length(x => x.RateRequestResponseCode, 1);
		validator.Length(x => x.ConveyanceCode, 1);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationQualifier2, 1, 2);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.LocationIdentifier2, 1, 25);
		validator.Length(x => x.ConditionCode, 4);
		validator.Length(x => x.ConditionValue, 1, 10);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		return validator.Results;
	}
}
