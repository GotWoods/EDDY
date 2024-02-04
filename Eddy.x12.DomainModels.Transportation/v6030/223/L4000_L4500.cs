using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Transportation.v6030._223;

public class L4000_L4500 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(3)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(4)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(7)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(8)] public List<L4000__L4500_L4510> L4510 {get;set;} = new();
	[SectionPosition(9)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(10)] public List<L4000__L4500_L4520> L4520 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L4000_L4500>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.L4510, 0, 9999);
		validator.CollectionSize(x => x.L4520, 0, 9999);
		foreach (var item in L4510) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L4520) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
