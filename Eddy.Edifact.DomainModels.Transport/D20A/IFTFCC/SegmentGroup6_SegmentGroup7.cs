using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D20A;

namespace Eddy.Edifact.DomainModels.Transport.D20A.IFTFCC;

public class SegmentGroup6_SegmentGroup7 {
	[SectionPosition(1)] public PRI_PriceDetails PriceDetails { get; set; } = new();
	[SectionPosition(2)] public List<CUX_Currencies> Currencies { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6_SegmentGroup7>(this);
		validator.Required(x => x.PriceDetails);
		validator.CollectionSize(x => x.Currencies, 1, 9);
		return validator.Results;
	}
}
