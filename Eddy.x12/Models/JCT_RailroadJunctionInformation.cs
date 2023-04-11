using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("JCT")]
public class JCT_RailroadJunctionInformation : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(03)]
	public string FreightStationAccountingCode { get; set; }

	[Position(04)]
	public string FreightStationAccountingCode2 { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode3 { get; set; }

	[Position(06)]
	public string StandardCarrierAlphaCode4 { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(08)]
	public string InterchangeTypeCode { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<JCT_RailroadJunctionInformation>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.StandardCarrierAlphaCode2);
		validator.Required(x=>x.StandardCarrierAlphaCode3);
		validator.Required(x=>x.StandardCarrierAlphaCode4);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Required(x=>x.InterchangeTypeCode);
		validator.Required(x=>x.YesNoConditionOrResponseCode2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.FreightStationAccountingCode, 1, 5);
		validator.Length(x => x.FreightStationAccountingCode2, 1, 5);
		validator.Length(x => x.StandardCarrierAlphaCode3, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode4, 2, 4);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.InterchangeTypeCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
