using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98A;

namespace Eddy.Edifact.DomainModels.Transport.D98A.IFTDGN;

public class SegmentGroup6_SegmentGroup10 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public PCI_PackageIdentification PackageIdentification { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup6__SegmentGroup10_SegmentGroup11> SegmentGroup11 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup6__SegmentGroup10_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6_SegmentGroup10>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.CollectionSize(x => x.FreeText, 1, 2);
		validator.Required(x => x.PackageIdentification);
		validator.CollectionSize(x => x.SegmentGroup11, 0, 99);
		foreach (var item in SegmentGroup11) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
