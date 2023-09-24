using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("CD")]
public class CD_ShipmentConditions : EdiX12Segment
{
	[Position(01)]
	public string ConditionSegmentLogicalConnector { get; set; }

	[Position(02)]
	public string ConditionCode { get; set; }

	[Position(03)]
	public string ConditionValue { get; set; }

	[Position(04)]
	public string ConditionValue2 { get; set; }

	[Position(05)]
	public string ConditionValue3 { get; set; }

	[Position(06)]
	public int? AssignedNumber { get; set; }

	[Position(07)]
	public string ChangeTypeCode { get; set; }

	[Position(08)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(09)]
	public string DocketControlNumber { get; set; }

	[Position(10)]
	public string DocketIdentification { get; set; }

	[Position(11)]
	public string GroupTitle { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CD_ShipmentConditions>(this);
		validator.Required(x=>x.ConditionSegmentLogicalConnector);
		validator.OnlyOneOf(x=>x.ConditionCode, x=>x.StandardCarrierAlphaCode);
		validator.ARequiresB(x=>x.ConditionValue, x=>x.ConditionCode);
		validator.ARequiresB(x=>x.ConditionValue2, x=>x.ConditionCode);
		validator.ARequiresB(x=>x.ConditionValue3, x=>x.ConditionCode);
		validator.Length(x => x.ConditionSegmentLogicalConnector, 1, 3);
		validator.Length(x => x.ConditionCode, 4);
		validator.Length(x => x.ConditionValue, 1, 10);
		validator.Length(x => x.ConditionValue2, 1, 10);
		validator.Length(x => x.ConditionValue3, 1, 10);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.ChangeTypeCode, 1);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.DocketControlNumber, 1, 7);
		validator.Length(x => x.DocketIdentification, 1, 11);
		validator.Length(x => x.GroupTitle, 2, 30);
		return validator.Results;
	}
}
