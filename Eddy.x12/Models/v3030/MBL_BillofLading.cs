using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("MBL")]
public class MBL_BillOfLading : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string BillOfLadingWaybillNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MBL_BillOfLading>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 12);
		return validator.Results;
	}
}
