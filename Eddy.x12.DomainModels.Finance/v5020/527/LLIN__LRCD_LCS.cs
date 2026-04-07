using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Finance.v5020._527;

public class LLIN__LRCD_LCS {
	[SectionPosition(1)] public CS_ContractSummary ContractSummary { get; set; } = new();
	[SectionPosition(2)] public PO4_ItemPhysicalDetails? ItemPhysicalDetails { get; set; }
	[SectionPosition(3)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(5)] public List<G69_LineItemDetailDescription> LineItemDetailDescription { get; set; } = new();
	[SectionPosition(6)] public List<LLIN__LRCD__LCS_LLM> LLM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLIN__LRCD_LCS>(this);
		validator.Required(x => x.ContractSummary);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 5);
		validator.CollectionSize(x => x.DateTime, 0, 5);
		validator.CollectionSize(x => x.LineItemDetailDescription, 0, 5);
		validator.CollectionSize(x => x.LLM, 0, 25);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
