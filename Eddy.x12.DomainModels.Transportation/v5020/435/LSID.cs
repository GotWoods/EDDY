using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Transportation.v5020._435;

public class LSID {
	[SectionPosition(1)] public SID_StandardTransportationCommodityCodeIdentification StandardTransportationCommodityCodeIdentification { get; set; } = new();
	[SectionPosition(2)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<LSID_LLQ> LLQ {get;set;} = new();
	[SectionPosition(5)] public List<LSID_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSID>(this);
		validator.Required(x => x.StandardTransportationCommodityCodeIdentification);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 30);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.LLQ, 0, 100);
		validator.CollectionSize(x => x.LLX, 0, 4);
		foreach (var item in LLQ) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
