using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("A4")]
public class A4_ApplicationAcceptance : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetControlNumber { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(05)]
	public string ReferenceNumber { get; set; }

	[Position(06)]
	public int? WaybillNumber { get; set; }

	[Position(07)]
	public string Date { get; set; }

	[Position(08)]
	public int? TotalEquipment { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<A4_ApplicationAcceptance>(this);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.Length(x => x.TransactionSetControlNumber, 4, 9);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.WaybillNumber, 1, 6);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.TotalEquipment, 1, 3);
		return validator.Results;
	}
}
