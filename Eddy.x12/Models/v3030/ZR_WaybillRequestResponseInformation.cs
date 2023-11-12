using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("ZR")]
public class ZR_WaybillReferenceIdentification : EdiX12Segment
{
	[Position(01)]
	public string WaybillResponseCode { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public int? WaybillNumber { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string FreeFormMessage { get; set; }

	[Position(07)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(08)]
	public string Date2 { get; set; }

	[Position(09)]
	public string InterlineSettlementSystemStatusActionOrDisputeCode { get; set; }

	[Position(10)]
	public string InterlineSettlementSystemStatusActionOrDisputeCode2 { get; set; }

	[Position(11)]
	public string ReferenceNumber { get; set; }

	[Position(12)]
	public string ReferenceNumber2 { get; set; }

	[Position(13)]
	public string CorrectionIndicator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ZR_WaybillReferenceIdentification>(this);
		validator.Required(x=>x.WaybillResponseCode);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Length(x => x.WaybillResponseCode, 1);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.WaybillNumber, 1, 6);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.InterlineSettlementSystemStatusActionOrDisputeCode, 2);
		validator.Length(x => x.InterlineSettlementSystemStatusActionOrDisputeCode2, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		validator.Length(x => x.CorrectionIndicator, 2);
		return validator.Results;
	}
}
