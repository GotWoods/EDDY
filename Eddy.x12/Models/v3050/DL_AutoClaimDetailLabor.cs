using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("DL")]
public class DL_AutoClaimDetailLabor : EdiX12Segment
{
	[Position(01)]
	public string ActionCode { get; set; }

	[Position(02)]
	public string LaborHours { get; set; }

	[Position(03)]
	public string LaborHours2 { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public string Amount { get; set; }

	[Position(06)]
	public int? Number { get; set; }

	[Position(07)]
	public int? Number2 { get; set; }

	[Position(08)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode4 { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DL_AutoClaimDetailLabor>(this);
		validator.Required(x=>x.ActionCode);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.LaborHours, 1, 3);
		validator.Length(x => x.LaborHours2, 1, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Number2, 1, 9);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode4, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode5, 1);
		return validator.Results;
	}
}
