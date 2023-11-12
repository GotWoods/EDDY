using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4040;

[Segment("ED")]
public class ED_EquipmentDescription : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public string LoadEmptyStatusCode { get; set; }

	[Position(04)]
	public string CommodityCode { get; set; }

	[Position(05)]
	public string LadingDescription { get; set; }

	[Position(06)]
	public int? WaybillNumber { get; set; }

	[Position(07)]
	public string EquipmentNumber2 { get; set; }

	[Position(08)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ED_EquipmentDescription>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.LoadEmptyStatusCode, 1);
		validator.Length(x => x.CommodityCode, 1, 30);
		validator.Length(x => x.LadingDescription, 1, 50);
		validator.Length(x => x.WaybillNumber, 1, 6);
		validator.Length(x => x.EquipmentNumber2, 1, 15);
		validator.Length(x => x.Date, 8);
		return validator.Results;
	}
}
