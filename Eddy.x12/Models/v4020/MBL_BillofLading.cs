using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("MBL")]
public class MBL_BillOfLading : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(03)]
	public string ActionCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public string TypeOfServiceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MBL_BillOfLading>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 25);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.TypeOfServiceCode, 2);
		return validator.Results;
	}
}
