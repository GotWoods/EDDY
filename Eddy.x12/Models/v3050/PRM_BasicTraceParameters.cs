using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("PRM")]
public class PRM_BasicTraceParameters : EdiX12Segment
{
	[Position(01)]
	public string CarTypeCode { get; set; }

	[Position(02)]
	public string LoadEmptyStatusCode { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(04)]
	public string StandardPointLocationCode { get; set; }

	[Position(05)]
	public string StandardPointLocationCode2 { get; set; }

	[Position(06)]
	public string CommodityCode { get; set; }

	[Position(07)]
	public string IdentificationCode { get; set; }

	[Position(08)]
	public string IdentificationCode2 { get; set; }

	[Position(09)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(10)]
	public string StandardCarrierAlphaCode3 { get; set; }

	[Position(11)]
	public string StandardPointLocationCode3 { get; set; }

	[Position(12)]
	public string StandardCarrierAlphaCode4 { get; set; }

	[Position(13)]
	public string TransportationConditionCode { get; set; }

	[Position(14)]
	public string AssociationOfAmericanRailroadsCarGradeCode { get; set; }

	[Position(15)]
	public string IntermodalServiceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRM_BasicTraceParameters>(this);
		validator.Length(x => x.CarTypeCode, 1, 4);
		validator.Length(x => x.LoadEmptyStatusCode, 1);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.StandardPointLocationCode2, 6, 9);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.IdentificationCode2, 2, 20);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode3, 2, 4);
		validator.Length(x => x.StandardPointLocationCode3, 6, 9);
		validator.Length(x => x.StandardCarrierAlphaCode4, 2, 4);
		validator.Length(x => x.TransportationConditionCode, 1);
		validator.Length(x => x.AssociationOfAmericanRailroadsCarGradeCode, 1);
		validator.Length(x => x.IntermodalServiceCode, 1, 2);
		return validator.Results;
	}
}
