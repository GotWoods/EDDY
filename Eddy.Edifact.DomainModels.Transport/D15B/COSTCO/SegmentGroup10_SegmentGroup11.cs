using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15B;

namespace Eddy.Edifact.DomainModels.Transport.D15B.COSTCO;

public class SegmentGroup10_SegmentGroup11 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup10__SegmentGroup11_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	[SectionPosition(4)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(5)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(6)] public List<PCI_PackageIdentification> PackageIdentification { get; set; } = new();
	[SectionPosition(7)] public List<DOC_DocumentMessageDetails> DocumentMessageDetails { get; set; } = new();
	[SectionPosition(8)] public List<SegmentGroup10__SegmentGroup11_SegmentGroup13> SegmentGroup13 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup10__SegmentGroup11_SegmentGroup14> SegmentGroup14 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup10_SegmentGroup11>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.PackageIdentification, 1, 9);
		validator.CollectionSize(x => x.DocumentMessageDetails, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup12, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup13, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup14, 0, 99);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup13) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup14) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
