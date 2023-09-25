using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5050;

[Segment("X02")]
public class X02_AutomatedManifestBillsEligibleOverdueArchiveDetails : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(03)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(04)]
	public string StandardCarrierAlphaCode3 { get; set; }

	[Position(05)]
	public string BillOfLadingWaybillNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<X02_AutomatedManifestBillsEligibleOverdueArchiveDetails>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.StandardCarrierAlphaCode2);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.StandardCarrierAlphaCode3, x=>x.BillOfLadingWaybillNumber2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 50);
		validator.Length(x => x.StandardCarrierAlphaCode3, 2, 4);
		validator.Length(x => x.BillOfLadingWaybillNumber2, 1, 50);
		return validator.Results;
	}
}
