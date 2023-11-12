using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("R12")]
public class R12_WorkOrderInformation : EdiX12Segment
{
	[Position(01)]
	public int? NumberOfLineItems { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public string ReferenceIdentification { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string LocationIdentifier { get; set; }

	[Position(07)]
	public string LoadEmptyStatusCode { get; set; }

	[Position(08)]
	public string EquipmentInitial2 { get; set; }

	[Position(09)]
	public string EquipmentNumber2 { get; set; }

	[Position(10)]
	public int? EquipmentNumberCheckDigit { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<R12_WorkOrderInformation>(this);
		validator.Required(x=>x.NumberOfLineItems);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.EquipmentInitial2, x=>x.EquipmentNumber2);
		validator.Length(x => x.NumberOfLineItems, 1, 6);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.LoadEmptyStatusCode, 1);
		validator.Length(x => x.EquipmentInitial2, 1, 4);
		validator.Length(x => x.EquipmentNumber2, 1, 10);
		validator.Length(x => x.EquipmentNumberCheckDigit, 1);
		return validator.Results;
	}
}
