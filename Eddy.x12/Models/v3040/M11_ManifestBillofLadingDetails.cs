using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

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
	public string WeightUnitCode { get; set; }

	[Position(07)]
	public decimal? Volume { get; set; }

	[Position(08)]
	public string VolumeUnitQualifier { get; set; }

	[Position(09)]
	public string BillOfLadingTypeCode { get; set; }

	[Position(10)]
	public string PlaceOfReceiptByPreCarrier { get; set; }

	[Position(11)]
	public string BillOfLadingWaybillNumber2 { get; set; }

	[Position(12)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(13)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(14)]
	public string StandardCarrierAlphaCode3 { get; set; }

	[Position(15)]
	public string StandardCarrierAlphaCode4 { get; set; }

	[Position(16)]
	public string ShippersExportDeclarationRequirements { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M11_ManifestBillOfLadingDetails>(this);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Required(x=>x.LocationIdentifier);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.ManifestUnitCode);
		validator.Required(x=>x.Weight);
		validator.Required(x=>x.WeightUnitCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.VolumeUnitQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.BillOfLadingWaybillNumber2, x=>x.StandardCarrierAlphaCode2);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 12);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ManifestUnitCode, 1, 3);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.BillOfLadingTypeCode, 2);
		validator.Length(x => x.PlaceOfReceiptByPreCarrier, 1, 17);
		validator.Length(x => x.BillOfLadingWaybillNumber2, 1, 12);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode3, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode4, 2, 4);
		validator.Length(x => x.ShippersExportDeclarationRequirements, 1, 2);
		return validator.Results;
	}
}
