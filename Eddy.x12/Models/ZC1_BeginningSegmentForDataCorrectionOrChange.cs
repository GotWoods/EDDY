using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("ZC1")]
public class ZC1_BeginningSegmentForDataCorrectionOrChange : EdiX12Segment
{
	[Position(01)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public string TransactionReferenceNumber { get; set; }

	[Position(05)]
	public string TransactionReferenceDate { get; set; }

	[Position(06)]
	public string CorrectionIndicatorCode { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(08)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(09)]
	public int? EquipmentNumberCheckDigit { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ZC1_BeginningSegmentForDataCorrectionOrChange>(this);
		validator.Required(x=>x.EquipmentNumber);
		validator.Required(x=>x.TransactionReferenceNumber);
		validator.Required(x=>x.TransactionReferenceDate);
		validator.Required(x=>x.CorrectionIndicatorCode);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.TransactionReferenceNumber, 1, 50);
		validator.Length(x => x.TransactionReferenceDate, 8);
		validator.Length(x => x.CorrectionIndicatorCode, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.EquipmentNumberCheckDigit, 1);
		return validator.Results;
	}
}
