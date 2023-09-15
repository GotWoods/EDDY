using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("CD1")]
public class CD1_CargoDetail : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public string EquipmentType { get; set; }

	[Position(04)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(05)]
	public string TypeOfServiceCode { get; set; }

	[Position(06)]
	public string HazardousMaterialCodeQualifier { get; set; }

	[Position(07)]
	public string HazardousMaterialClassCode { get; set; }

	[Position(08)]
	public string Date { get; set; }

	[Position(09)]
	public string LocationIdentifier { get; set; }

	[Position(10)]
	public decimal? Quantity { get; set; }

	[Position(11)]
	public string PackagingCode { get; set; }

	[Position(12)]
	public string DispositionCode { get; set; }

	[Position(13)]
	public string DispositionCode2 { get; set; }

	[Position(14)]
	public string DispositionCode3 { get; set; }

	[Position(15)]
	public string RateClassCode { get; set; }

	[Position(16)]
	public string RateValueQualifier { get; set; }

	[Position(17)]
	public decimal? Rate { get; set; }

	[Position(18)]
	public string RateClassCode2 { get; set; }

	[Position(19)]
	public string RateValueQualifier2 { get; set; }

	[Position(20)]
	public decimal? Rate2 { get; set; }

	[Position(21)]
	public string RateClassCode3 { get; set; }

	[Position(22)]
	public string RateValueQualifier3 { get; set; }

	[Position(23)]
	public decimal? Rate3 { get; set; }

	[Position(24)]
	public string DateTimeQualifier { get; set; }

	[Position(25)]
	public string DeliveryDate { get; set; }

	[Position(26)]
	public string StatusCode { get; set; }

	[Position(27)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(28)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(29)]
	public string ReferenceNumber { get; set; }

	[Position(30)]
	public string ReferenceNumberQualifier2 { get; set; }

	[Position(31)]
	public string ReferenceNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CD1_CargoDetail>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Required(x=>x.TypeOfServiceCode);
		validator.Required(x=>x.LocationIdentifier);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.PackagingCode);
		validator.Required(x=>x.DispositionCode);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.ReferenceNumberQualifier2);
		validator.Required(x=>x.ReferenceNumber2);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.EquipmentType, 4);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 12);
		validator.Length(x => x.TypeOfServiceCode, 2);
		validator.Length(x => x.HazardousMaterialCodeQualifier, 1);
		validator.Length(x => x.HazardousMaterialClassCode, 2, 4);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.PackagingCode, 5);
		validator.Length(x => x.DispositionCode, 2);
		validator.Length(x => x.DispositionCode2, 2);
		validator.Length(x => x.DispositionCode3, 2);
		validator.Length(x => x.RateClassCode, 1, 3);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Rate, 1, 7);
		validator.Length(x => x.RateClassCode2, 1, 3);
		validator.Length(x => x.RateValueQualifier2, 2);
		validator.Length(x => x.Rate2, 1, 7);
		validator.Length(x => x.RateClassCode3, 1, 3);
		validator.Length(x => x.RateValueQualifier3, 2);
		validator.Length(x => x.Rate3, 1, 7);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.DeliveryDate, 6);
		validator.Length(x => x.StatusCode, 1, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumberQualifier2, 2);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		return validator.Results;
	}
}
