using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._160;

public class LEI {
	[SectionPosition(1)] public EI_AutomaticEquipmentIdentification AutomaticEquipmentIdentification { get; set; } = new();
	[SectionPosition(2)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public List<LEI_LTSI> LTSI {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LEI>(this);
		validator.Required(x => x.AutomaticEquipmentIdentification);
		validator.CollectionSize(x => x.Quantity, 0, 20);
		validator.CollectionSize(x => x.Measurements, 0, 20);
		validator.CollectionSize(x => x.DateTimeReference, 0, 20);
		validator.CollectionSize(x => x.LTSI, 0, 25);
		foreach (var item in LTSI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
