using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("SW")]
public class SW_SwitchingCharges : EdiX12Segment
{
	[Position(01)]
	public string TariffApplicationCode { get; set; }

	[Position(02)]
	public string ConditionSegmentLogicalConnector { get; set; }

	[Position(03)]
	public string ConditionCode { get; set; }

	[Position(04)]
	public string ConditionValue { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(06)]
	public string RateValueQualifier { get; set; }

	[Position(07)]
	public decimal? Rate { get; set; }

	[Position(08)]
	public string Rule260JunctionCode { get; set; }

	[Position(09)]
	public int? AssignedNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SW_SwitchingCharges>(this);
		validator.Required(x=>x.TariffApplicationCode);
		validator.Required(x=>x.ConditionSegmentLogicalConnector);
		validator.Required(x=>x.ConditionCode);
		validator.Required(x=>x.ConditionValue);
		validator.Length(x => x.TariffApplicationCode, 1);
		validator.Length(x => x.ConditionSegmentLogicalConnector, 2, 3);
		validator.Length(x => x.ConditionCode, 4);
		validator.Length(x => x.ConditionValue, 1, 10);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Rate, 1, 7);
		validator.Length(x => x.Rule260JunctionCode, 1, 5);
		validator.Length(x => x.AssignedNumber, 1, 6);
		return validator.Results;
	}
}
