using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("M20")]
public class M20_PermitToTransferRequestDetails : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(03)]
	public string EquipmentInitial { get; set; }

	[Position(04)]
	public string EquipmentNumber { get; set; }

	[Position(05)]
	public string LocationQualifier { get; set; }

	[Position(06)]
	public string LocationIdentifier { get; set; }

	[Position(07)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(08)]
	public string ReferenceNumber { get; set; }

	[Position(09)]
	public string FreeFormDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M20_PermitToTransferRequestDetails>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Required(x=>x.LocationQualifier);
		validator.Required(x=>x.LocationIdentifier);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 12);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		return validator.Results;
	}
}
