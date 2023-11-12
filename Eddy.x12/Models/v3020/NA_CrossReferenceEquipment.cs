using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("NA")]
public class NA_CrossReferenceEquipment : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string EquipmentInitial { get; set; }

	[Position(04)]
	public string EquipmentNumber { get; set; }

	[Position(05)]
	public string CrossReferenceTypeCode { get; set; }

	[Position(06)]
	public string Position { get; set; }

	[Position(07)]
	public string EquipmentOwnerCode { get; set; }

	[Position(08)]
	public int? EquipmentLength { get; set; }

	[Position(09)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(10)]
	public string ChassisType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<NA_CrossReferenceEquipment>(this);
		validator.ARequiresB(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.Required(x=>x.EquipmentInitial);
		validator.Required(x=>x.EquipmentNumber);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.CrossReferenceTypeCode, 1);
		validator.Length(x => x.Position, 1, 3);
		validator.Length(x => x.EquipmentOwnerCode, 1, 4);
		validator.Length(x => x.EquipmentLength, 4, 5);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ChassisType, 2);
		return validator.Results;
	}
}
