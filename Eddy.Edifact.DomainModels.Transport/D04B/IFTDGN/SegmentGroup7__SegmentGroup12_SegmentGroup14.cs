using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D04B;

namespace Eddy.Edifact.DomainModels.Transport.D04B.IFTDGN;

public class SegmentGroup7__SegmentGroup12_SegmentGroup14 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(4)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(5)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(6)] public List<SegmentGroup7__SegmentGroup12__SegmentGroup14_SegmentGroup15> SegmentGroup15 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup7__SegmentGroup12_SegmentGroup14>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 99);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup15, 0, 99);
		foreach (var item in SegmentGroup15) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
