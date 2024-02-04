using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._250;

public class L0100 {
	[SectionPosition(1)] public PRF_PurchaseOrderReference PurchaseOrderReference { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public FOB_FOBRelatedInstructions? FOBRelatedInstructions { get; set; }
	[SectionPosition(4)] public G05_TotalShipmentInformation? TotalShipmentInformation { get; set; }
	[SectionPosition(5)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(6)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(7)] public List<L0100_L0110> L0110 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0100>(this);
		validator.Required(x => x.PurchaseOrderReference);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 6);
		validator.CollectionSize(x => x.L0110, 1, 2147483647);
		foreach (var item in L0110) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
