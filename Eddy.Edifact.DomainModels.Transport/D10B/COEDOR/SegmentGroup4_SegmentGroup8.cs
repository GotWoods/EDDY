using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D10B;

namespace Eddy.Edifact.DomainModels.Transport.D10B.COEDOR;

public class SegmentGroup4_SegmentGroup8 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup4__SegmentGroup8_SegmentGroup9> SegmentGroup9 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4_SegmentGroup8>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup9, 0, 9);
		foreach (var item in SegmentGroup9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
