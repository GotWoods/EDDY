using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._422;

public class LLX__LF9_LSCO {
	[SectionPosition(1)] public SCO_ShippersCarOrdered ShippersCarOrdered { get; set; } = new();
	[SectionPosition(2)] public G62_DateTime? DateTime { get; set; }
	[SectionPosition(3)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public List<LLX__LF9__LSCO_LN7> LN7 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LF9_LSCO>(this);
		validator.Required(x => x.ShippersCarOrdered);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 4);
		validator.CollectionSize(x => x.LN7, 0, 9999);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
