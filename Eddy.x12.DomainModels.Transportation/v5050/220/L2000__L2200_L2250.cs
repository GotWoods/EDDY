using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Transportation.v5050._220;

public class L2000__L2200_L2250 {
	[SectionPosition(1)] public LAD_LadingDetail LadingDetail { get; set; } = new();
	[SectionPosition(2)] public PO4_ItemPhysicalDetails? ItemPhysicalDetails { get; set; }
	[SectionPosition(3)] public List<G69_LineItemDetailDescription> LineItemDetailDescription { get; set; } = new();
	[SectionPosition(4)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(5)] public AMT_MonetaryAmountInformation? MonetaryAmountInformation { get; set; }
	[SectionPosition(6)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2200_L2250>(this);
		validator.Required(x => x.LadingDetail);
		validator.CollectionSize(x => x.LineItemDetailDescription, 0, 99);
		validator.CollectionSize(x => x.BillOfLadingHandlingRequirements, 0, 6);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 1, 2147483647);
		return validator.Results;
	}
}
