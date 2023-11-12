using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("M13")]
public class M13_ManifestAmendmentDetails : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string LocationIdentifier { get; set; }

	[Position(03)]
	public string AmendmentTypeCode { get; set; }

	[Position(04)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string AmendmentCode { get; set; }

	[Position(07)]
	public string ActionCode { get; set; }

	[Position(08)]
	public string BillOfLadingWaybillNumber2 { get; set; }

	[Position(09)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(10)]
	public string StandardCarrierAlphaCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M13_ManifestAmendmentDetails>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.LocationIdentifier);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.BillOfLadingWaybillNumber2, x=>x.StandardCarrierAlphaCode3);
		validator.Required(x=>x.StandardCarrierAlphaCode2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.AmendmentTypeCode, 1);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 12);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.AmendmentCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.BillOfLadingWaybillNumber2, 1, 12);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode3, 2, 4);
		return validator.Results;
	}
}
