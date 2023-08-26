using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("A3")]
public class A3_ApplicationRejection : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetControlNumber { get; set; }

	[Position(02)]
	public string ReferenceDesignator { get; set; }

	[Position(03)]
	public string ErrorFieldData { get; set; }

	[Position(04)]
	public string EquipmentInitial { get; set; }

	[Position(05)]
	public string EquipmentNumber { get; set; }

	[Position(06)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(07)]
	public string ReferenceNumber { get; set; }

	[Position(08)]
	public string ApplicationErrorConditionCode { get; set; }

	[Position(09)]
	public string TransactionSetAcknowledgmentCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<A3_ApplicationRejection>(this);
		validator.Required(x=>x.ReferenceDesignator);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.Required(x=>x.TransactionSetAcknowledgmentCode);
		validator.Length(x => x.TransactionSetControlNumber, 4, 9);
		validator.Length(x => x.ReferenceDesignator, 4, 5);
		validator.Length(x => x.ErrorFieldData, 1, 12);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ApplicationErrorConditionCode, 1, 3);
		validator.Length(x => x.TransactionSetAcknowledgmentCode, 1);
		return validator.Results;
	}
}
