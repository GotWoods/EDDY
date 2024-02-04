using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Transportation.v8020._854;

public class LLX__LN1_LQ8 {
	[SectionPosition(1)] public Q8_DetailDeliveryExceptionInformation DetailDeliveryExceptionInformation { get; set; } = new();
	[SectionPosition(2)] public G62_DateTime? DateTime { get; set; }
	[SectionPosition(3)] public K1_Remarks? Remarks { get; set; }
	[SectionPosition(4)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(5)] public List<LLX__LN1__LQ8_LN1> LN1 {get;set;} = new();
	[SectionPosition(6)] public LE_LoopTrailer? LoopTrailer { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LN1_LQ8>(this);
		validator.Required(x => x.DetailDeliveryExceptionInformation);
		validator.CollectionSize(x => x.LN1, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
