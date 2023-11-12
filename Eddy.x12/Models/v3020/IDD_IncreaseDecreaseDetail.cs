using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("IDD")]
public class IDD_IncreaseDecreaseDetail : EdiX12Segment
{
	[Position(01)]
	public string TariffItemNumber { get; set; }

	[Position(02)]
	public string ConditionSegmentLogicalConnector { get; set; }

	[Position(03)]
	public string ConditionCode { get; set; }

	[Position(04)]
	public string ConditionValue { get; set; }

	[Position(05)]
	public string ConditionValue2 { get; set; }

	[Position(06)]
	public string ConditionValue3 { get; set; }

	[Position(07)]
	public string ConditionCode2 { get; set; }

	[Position(08)]
	public string ConditionValue4 { get; set; }

	[Position(09)]
	public string ConditionValue5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IDD_IncreaseDecreaseDetail>(this);
		validator.Required(x=>x.TariffItemNumber);
		validator.Required(x=>x.ConditionSegmentLogicalConnector);
		validator.Required(x=>x.ConditionCode);
		validator.Required(x=>x.ConditionValue);
		validator.Required(x=>x.ConditionValue2);
		validator.Required(x=>x.ConditionValue3);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.ConditionCode2, x=>x.ConditionValue4, x=>x.ConditionValue5);
		validator.Length(x => x.TariffItemNumber, 1, 16);
		validator.Length(x => x.ConditionSegmentLogicalConnector, 2, 3);
		validator.Length(x => x.ConditionCode, 4);
		validator.Length(x => x.ConditionValue, 1, 10);
		validator.Length(x => x.ConditionValue2, 1, 10);
		validator.Length(x => x.ConditionValue3, 1, 10);
		validator.Length(x => x.ConditionCode2, 4);
		validator.Length(x => x.ConditionValue4, 1, 10);
		validator.Length(x => x.ConditionValue5, 1, 10);
		return validator.Results;
	}
}
