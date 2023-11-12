using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("M11")]
public class M11_ManifestBillOfLadingDetails : EdiX12Segment
{
	[Position(01)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(02)]
	public string LocationIdentifier { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public string ManifestUnitCode { get; set; }

	[Position(05)]
	public decimal? Weight { get; set; }

	[Position(06)]
	public string WeightUnitQualifier { get; set; }

	[Position(07)]
	public decimal? Volume { get; set; }

	[Position(08)]
	public string VolumeUnitQualifier { get; set; }

	[Position(09)]
	public string BillOfLadingStatusCode { get; set; }

	[Position(10)]
	public string PlaceOfReceiptByPreCarrier { get; set; }

	[Position(11)]
	public string BillOfLadingWaybillNumber2 { get; set; }

	[Position(12)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(13)]
	public string StandardCarrierAlphaCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M11_ManifestBillOfLadingDetails>(this);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Required(x=>x.LocationIdentifier);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.ManifestUnitCode);
		validator.Required(x=>x.Weight);
		validator.Required(x=>x.WeightUnitQualifier);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 12);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.ManifestUnitCode, 1, 3);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.WeightUnitQualifier, 1);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.BillOfLadingStatusCode, 2);
		validator.Length(x => x.PlaceOfReceiptByPreCarrier, 1, 17);
		validator.Length(x => x.BillOfLadingWaybillNumber2, 1, 12);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		return validator.Results;
	}
}
