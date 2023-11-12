using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("M14")]
public class M14_GeneralOrderStatusInformation : EdiX12Segment
{
	[Position(01)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(02)]
	public string BillOfLadingStatusCode { get; set; }

	[Position(03)]
	public string CustomsEntryNumber { get; set; }

	[Position(04)]
	public string CustomsEntryTypeCode { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string BillOfLadingWaybillNumber2 { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(08)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(09)]
	public decimal? Quantity { get; set; }

	[Position(10)]
	public string ReferenceIdentification { get; set; }

	[Position(11)]
	public string LocationIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M14_GeneralOrderStatusInformation>(this);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Required(x=>x.BillOfLadingStatusCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.BillOfLadingWaybillNumber2, x=>x.StandardCarrierAlphaCode2);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 25);
		validator.Length(x => x.BillOfLadingStatusCode, 1, 2);
		validator.Length(x => x.CustomsEntryNumber, 1, 15);
		validator.Length(x => x.CustomsEntryTypeCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.BillOfLadingWaybillNumber2, 1, 25);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		return validator.Results;
	}
}
