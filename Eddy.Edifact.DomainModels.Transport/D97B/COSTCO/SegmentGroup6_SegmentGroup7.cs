using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B;

namespace Eddy.Edifact.DomainModels.Transport.D97B.COSTCO;

public class SegmentGroup6_SegmentGroup7 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public List<TMP_Temperature> Temperature { get; set; } = new();
	[SectionPosition(4)] public List<RNG_RangeDetails> RangeDetails { get; set; } = new();
	[SectionPosition(5)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(6)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(7)] public List<PCI_PackageIdentification> PackageIdentification { get; set; } = new();
	[SectionPosition(8)] public List<DOC_DocumentMessageDetails> DocumentMessageDetails { get; set; } = new();
	[SectionPosition(9)] public List<SegmentGroup6__SegmentGroup7_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	[SectionPosition(10)] public List<SegmentGroup6__SegmentGroup7_SegmentGroup9> SegmentGroup9 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6_SegmentGroup7>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.Temperature, 1, 9);
		validator.CollectionSize(x => x.RangeDetails, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.PackageIdentification, 1, 9);
		validator.CollectionSize(x => x.DocumentMessageDetails, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup9, 0, 9);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
