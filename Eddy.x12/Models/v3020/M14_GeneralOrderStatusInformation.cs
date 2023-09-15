using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("M14")]
public class M14_GeneralOrderStatusInformation : EdiX12Segment
{
	[Position(01)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(02)]
	public string BillOfLadingStatusCode { get; set; }

	[Position(03)]
	public string EntryNumber { get; set; }

	[Position(04)]
	public string EntryTypeCode { get; set; }

	[Position(05)]
	public string ReleaseIssueDate { get; set; }

	[Position(06)]
	public string BillOfLadingWaybillNumber2 { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(08)]
	public string StandardCarrierAlphaCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M14_GeneralOrderStatusInformation>(this);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Required(x=>x.BillOfLadingStatusCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.BillOfLadingWaybillNumber2, x=>x.StandardCarrierAlphaCode2);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 12);
		validator.Length(x => x.BillOfLadingStatusCode, 1, 2);
		validator.Length(x => x.EntryNumber, 1, 15);
		validator.Length(x => x.EntryTypeCode, 2);
		validator.Length(x => x.ReleaseIssueDate, 6);
		validator.Length(x => x.BillOfLadingWaybillNumber2, 1, 12);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		return validator.Results;
	}
}
