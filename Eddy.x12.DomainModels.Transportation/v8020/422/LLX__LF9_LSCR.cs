using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Transportation.v8020._422;

public class LLX__LF9_LSCR {
	[SectionPosition(1)] public SCR_ShippersCarOrderedRail ShippersCarOrderedRail { get; set; } = new();
	[SectionPosition(2)] public List<GA_CanadianGrainInformation> CanadianGrainInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(5)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(6)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public List<PI_PriceAuthorityIdentification> PriceAuthorityIdentification { get; set; } = new();
	[SectionPosition(8)] public List<LLX__LF9__LSCR_LLQ> LLQ {get;set;} = new();
	[SectionPosition(9)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(10)] public List<LLX__LF9__LSCR_LN7> LN7 {get;set;} = new();
	[SectionPosition(11)] public LE_LoopTrailer? LoopTrailer { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LF9_LSCR>(this);
		validator.Required(x => x.ShippersCarOrderedRail);
		validator.CollectionSize(x => x.CanadianGrainInformation, 0, 15);
		validator.CollectionSize(x => x.DateTimeReference, 1, 10);
		validator.CollectionSize(x => x.QuantityInformation, 0, 3);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 20);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 20);
		validator.CollectionSize(x => x.PriceAuthorityIdentification, 0, 3);
		validator.CollectionSize(x => x.LLQ, 0, 99);
		validator.CollectionSize(x => x.LN7, 0, 9999);
		foreach (var item in LLQ) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
