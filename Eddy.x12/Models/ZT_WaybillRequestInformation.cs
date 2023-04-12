using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("ZT")]
public class ZT_WaybillRequestInformation : EdiX12Segment
{
	[Position(01)]
	public string WaybillRequestCode { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public int? WaybillNumber { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public int? EquipmentNumberCheckDigit { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ZT_WaybillRequestInformation>(this);
		validator.Required(x=>x.WaybillRequestCode);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WaybillNumber, x=>x.Date);
		validator.Length(x => x.WaybillRequestCode, 1);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.WaybillNumber, 1, 6);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.EquipmentNumberCheckDigit, 1);
		return validator.Results;
	}
}
