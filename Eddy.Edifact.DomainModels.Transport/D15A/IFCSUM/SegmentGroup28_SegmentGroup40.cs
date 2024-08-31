using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15A;

namespace Eddy.Edifact.DomainModels.Transport.D15A.IFCSUM;

public class SegmentGroup28_SegmentGroup40 {
	[SectionPosition(1)] public ICD_InsuranceCoverDescription InsuranceCoverDescription { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<FTX_FreeText> FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28_SegmentGroup40>(this);
		validator.Required(x => x.InsuranceCoverDescription);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		return validator.Results;
	}
}
