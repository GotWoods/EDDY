using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C;

namespace Eddy.Edifact.DomainModels.Transport.D01C.IFTDGN;

public class SegmentGroup7_SegmentGroup12 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public PCI_PackageIdentification PackageIdentification { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup7__SegmentGroup12_SegmentGroup13> SegmentGroup13 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup7__SegmentGroup12_SegmentGroup14> SegmentGroup14 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup7_SegmentGroup12>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.CollectionSize(x => x.FreeText, 1, 2);
		validator.Required(x => x.PackageIdentification);
		validator.CollectionSize(x => x.SegmentGroup13, 0, 99);
		foreach (var item in SegmentGroup13) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup14) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
