using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("BVA")]
public class BVA_BeginningVehicleAdvice : EdiX12Segment
{
	[Position(01)]
	public string PaymentTypeCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(04)]
	public string IdentificationCode { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string InvoiceNumber { get; set; }

	[Position(07)]
	public string IdentificationCodeQualifier2 { get; set; }

	[Position(08)]
	public string IdentificationCode2 { get; set; }

	[Position(09)]
	public string VehicleServiceCode { get; set; }

	[Position(10)]
	public string IdentificationCodeQualifier3 { get; set; }

	[Position(11)]
	public string IdentificationCode3 { get; set; }

	[Position(12)]
	public string CurrencyCode { get; set; }

	[Position(13)]
	public string LadingDescriptionQualifier { get; set; }

	[Position(14)]
	public string Date2 { get; set; }

	[Position(15)]
	public string ReferenceNumber { get; set; }

	[Position(16)]
	public string Date3 { get; set; }

	[Position(17)]
	public string CheckNumber { get; set; }

	[Position(18)]
	public string EquipmentInitial { get; set; }

	[Position(19)]
	public string EquipmentNumber { get; set; }

	[Position(20)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(21)]
	public decimal? Quantity { get; set; }

	[Position(22)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(23)]
	public string FlightVoyageNumber { get; set; }

	[Position(24)]
	public string VehicleStatus { get; set; }

	[Position(25)]
	public string TransactionSetPurposeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BVA_BeginningVehicleAdvice>(this);
		validator.Required(x=>x.PaymentTypeCode);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier2, x=>x.IdentificationCode2);
		validator.AtLeastOneIsRequired(x=>x.IdentificationCode2, x=>x.VehicleServiceCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier3, x=>x.IdentificationCode3);
		validator.Length(x => x.PaymentTypeCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.IdentificationCodeQualifier2, 1, 2);
		validator.Length(x => x.IdentificationCode2, 2, 20);
		validator.Length(x => x.VehicleServiceCode, 2, 4);
		validator.Length(x => x.IdentificationCodeQualifier3, 1, 2);
		validator.Length(x => x.IdentificationCode3, 2, 20);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.LadingDescriptionQualifier, 1);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Date3, 6);
		validator.Length(x => x.CheckNumber, 1, 16);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.FlightVoyageNumber, 2, 10);
		validator.Length(x => x.VehicleStatus, 1, 2);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		return validator.Results;
	}
}
