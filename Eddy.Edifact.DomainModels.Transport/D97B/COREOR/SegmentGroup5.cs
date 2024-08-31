using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B;

namespace Eddy.Edifact.DomainModels.Transport.D97B.COREOR;

public class SegmentGroup5 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup5_SegmentGroup6> SegmentGroup6 {get;set;} = new();
	[SectionPosition(5)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(6)] public List<PCI_PackageIdentification> PackageIdentification { get; set; } = new();
	[SectionPosition(7)] public List<SegmentGroup5_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	[SectionPosition(8)] public List<SegmentGroup5_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup5>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.PackageIdentification, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup6, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 9);
		foreach (var item in SegmentGroup6) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
