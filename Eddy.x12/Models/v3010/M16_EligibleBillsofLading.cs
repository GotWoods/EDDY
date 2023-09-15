using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("M16")]
public class M16_EligibleBillsOfLading : EdiX12Segment
{
	[Position(01)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string ReleaseIssueDate { get; set; }

	[Position(04)]
	public string BillOfLadingWaybillNumber2 { get; set; }

	[Position(05)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(06)]
	public string StandardCarrierAlphaCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M16_EligibleBillsOfLading>(this);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 12);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.ReleaseIssueDate, 6);
		validator.Length(x => x.BillOfLadingWaybillNumber2, 1, 12);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		return validator.Results;
	}
}
