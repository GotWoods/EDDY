using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Finance.v3040._820;

public class LN1_LRMT {
	[SectionPosition(1)] public RMT_RemittanceAdvice RemittanceAdvice { get; set; } = new();
	[SectionPosition(2)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(3)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1_LRMT>(this);
		validator.Required(x => x.RemittanceAdvice);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 15);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		return validator.Results;
	}
}
