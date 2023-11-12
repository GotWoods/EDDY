using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("ZD")]
public class ZD_TransactionSetDeletionIDReasonAndSource : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(02)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(03)]
	public string EquipmentInitial { get; set; }

	[Position(04)]
	public string EquipmentNumber { get; set; }

	[Position(05)]
	public string TransactionReferenceNumber { get; set; }

	[Position(06)]
	public string TransactionReferenceDate { get; set; }

	[Position(07)]
	public string CorrectionIndicator { get; set; }

	[Position(08)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(09)]
	public int? EquipmentNumberCheckDigit { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ZD_TransactionSetDeletionIDReasonAndSource>(this);
		validator.Required(x=>x.TransactionSetIdentifierCode);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Required(x=>x.CorrectionIndicator);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.TransactionReferenceNumber, 1, 15);
		validator.Length(x => x.TransactionReferenceDate, 8);
		validator.Length(x => x.CorrectionIndicator, 2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.EquipmentNumberCheckDigit, 1);
		return validator.Results;
	}
}
