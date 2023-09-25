using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("ZR")]
public class ZR_WaybillRequestResponseInformation : EdiX12Segment
{
	[Position(01)]
	public string WaybillRequestResponseCode { get; set; }

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ZR_WaybillRequestResponseInformation>(this);
		validator.Required(x=>x.WaybillRequestResponseCode);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Length(x => x.WaybillRequestResponseCode, 1);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.WaybillNumber, 1, 6);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		return validator.Results;
	}
}
