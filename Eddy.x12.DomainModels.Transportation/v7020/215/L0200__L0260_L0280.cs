using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._215;

public class L0200__L0260_L0280 {
	[SectionPosition(1)] public SLN_SublineItemDetail SublineItemDetail { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(4)] public List<N10_QuantityAndDescription> QuantityAndDescription { get; set; } = new();
	[SectionPosition(5)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(6)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200__L0260_L0280>(this);
		validator.Required(x => x.SublineItemDetail);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 10);
		validator.CollectionSize(x => x.QuantityAndDescription, 0, 10);
		validator.CollectionSize(x => x.TaxInformation, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		return validator.Results;
	}
}
