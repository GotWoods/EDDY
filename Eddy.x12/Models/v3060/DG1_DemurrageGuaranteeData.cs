using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("DG1")]
public class DG1_DemurrageGuaranteeData : EdiX12Segment
{
	[Position(01)]
	public string EquipmentInitial { get; set; }

	[Position(02)]
	public string EquipmentNumber { get; set; }

	[Position(03)]
	public string BillOfLadingWaybillNumber { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string AuthorizationIdentification { get; set; }

	[Position(06)]
	public string Date { get; set; }

	[Position(07)]
	public string Date2 { get; set; }

	[Position(08)]
	public string Amount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DG1_DemurrageGuaranteeData>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Required(x=>x.BillOfLadingWaybillNumber);
		validator.Required(x=>x.AuthorizationIdentification);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Date2);
		validator.Required(x=>x.Amount);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.BillOfLadingWaybillNumber, 1, 12);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.AuthorizationIdentification, 1, 4);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Amount, 1, 15);
		return validator.Results;
	}
}
