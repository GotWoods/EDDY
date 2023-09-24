using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5050;

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

	[Position(17)]
	public string ExportExceptionCode { get; set; }

	[Position(18)]
	public string StandardCarrierAlphaCode5 { get; set; }

	[Position(19)]
	public string StandardCarrierAlphaCode6 { get; set; }

	[Position(20)]
	public string LocationIdentifier2 { get; set; }

	[Position(21)]
	public string LocationIdentifier3 { get; set; }

	[Position(22)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(23)]
	public string PaymentMethodCode { get; set; }

	[Position(24)]
	public string IndustryCode { get; set; }

	[Position(25)]
	public string LocationQualifier { get; set; }

	[Position(26)]
	public string ServiceLevelCode { get; set; }

	[Position(27)]
	public string Date { get; set; }

	[Position(28)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M11_ManifestBillOfLadingDetails>(this);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Required(x=>x.LocationIdentifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.ManifestUnitCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Weight, x=>x.WeightUnitCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.VolumeUnitQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.BillOfLadingWaybillNumber2, x=>x.StandardCarrierAlphaCode2);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.ARequiresB(x=>x.StandardCarrierAlphaCode4, x=>x.StandardCarrierAlphaCode3);
		validator.ARequiresB(x=>x.StandardCarrierAlphaCode5, x=>x.StandardCarrierAlphaCode4);
		validator.ARequiresB(x=>x.StandardCarrierAlphaCode6, x=>x.StandardCarrierAlphaCode5);
		validator.Required(x=>x.LocationQualifier);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 50);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ManifestUnitCode, 1, 3);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.BillOfLadingTypeCode, 2);
		validator.Length(x => x.PlaceOfReceiptByPreCarrier, 1, 17);
		validator.Length(x => x.BillOfLadingWaybillNumber2, 1, 50);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode3, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode4, 2, 4);
		validator.Length(x => x.ShippersExportDeclarationRequirements, 1, 2);
		validator.Length(x => x.ExportExceptionCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode5, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode6, 2, 4);
		validator.Length(x => x.LocationIdentifier2, 1, 30);
		validator.Length(x => x.LocationIdentifier3, 1, 30);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.PaymentMethodCode, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.ServiceLevelCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
