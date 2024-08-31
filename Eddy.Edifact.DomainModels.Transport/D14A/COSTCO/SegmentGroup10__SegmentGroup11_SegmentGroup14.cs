using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D14A;

namespace Eddy.Edifact.DomainModels.Transport.D14A.COSTCO;

public class SegmentGroup10__SegmentGroup11_SegmentGroup14 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup10__SegmentGroup11__SegmentGroup14_SegmentGroup15> SegmentGroup15 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup10__SegmentGroup11__SegmentGroup14_SegmentGroup16> SegmentGroup16 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup10__SegmentGroup11_SegmentGroup14>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup15, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup16, 0, 999);
		foreach (var item in SegmentGroup15) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup16) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
