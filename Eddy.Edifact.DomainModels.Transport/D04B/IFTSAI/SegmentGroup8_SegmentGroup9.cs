using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D04B;

namespace Eddy.Edifact.DomainModels.Transport.D04B.IFTSAI;

public class SegmentGroup8_SegmentGroup9 {
	[SectionPosition(1)] public GDS_NatureOfCargo NatureOfCargo { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup8_SegmentGroup9>(this);
		validator.Required(x => x.NatureOfCargo);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		return validator.Results;
	}
}
