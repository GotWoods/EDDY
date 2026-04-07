using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Finance.v3020._819;

public class LJIL_LJID {
	[SectionPosition(1)] public JID_EquipmentDetail EquipmentDetail { get; set; } = new();
	[SectionPosition(2)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(5)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(6)] public List<MEA_Measurements> Measurements { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LJIL_LJID>(this);
		validator.Required(x => x.EquipmentDetail);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 99);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 12);
		validator.CollectionSize(x => x.MessageText, 0, 12);
		validator.CollectionSize(x => x.Measurements, 0, 5);
		return validator.Results;
	}
}
