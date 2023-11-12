using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CD_ShipmentConditions>(this);
		validator.Required(x=>x.ConditionSegmentLogicalConnector);
		validator.Required(x=>x.ConditionCode);
		validator.Length(x => x.ConditionSegmentLogicalConnector, 2, 3);
		validator.Length(x => x.ConditionCode, 4);
		validator.Length(x => x.ConditionValue, 1, 10);
		validator.Length(x => x.ConditionValue2, 1, 10);
		validator.Length(x => x.ConditionValue3, 1, 10);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.ChangeTypeCode, 1);
		return validator.Results;
	}
}
