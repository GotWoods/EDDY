using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01A;

namespace Eddy.Edifact.DomainModels.Transport.D01A.IFTFCC;

public class SegmentGroup16 {
	[SectionPosition(1)] public PAT_PaymentTermsBasis PaymentTermsBasis { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public PCD_PercentageDetails PercentageDetails { get; set; } = new();
	[SectionPosition(4)] public MOA_MonetaryAmount MonetaryAmount { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup16>(this);
		validator.Required(x => x.PaymentTermsBasis);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 5);
		validator.Required(x => x.PercentageDetails);
		validator.Required(x => x.MonetaryAmount);
		return validator.Results;
	}
}
