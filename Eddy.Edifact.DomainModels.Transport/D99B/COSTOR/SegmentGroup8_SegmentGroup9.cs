using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B;

namespace Eddy.Edifact.DomainModels.Transport.D99B.COSTOR;

public class SegmentGroup8_SegmentGroup9 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public List<TMP_Temperature> Temperature { get; set; } = new();
	[SectionPosition(4)] public List<RNG_RangeDetails> RangeDetails { get; set; } = new();
	[SectionPosition(5)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(6)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(7)] public List<SegmentGroup8__SegmentGroup9_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	[SectionPosition(8)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(9)] public List<PCI_PackageIdentification> PackageIdentification { get; set; } = new();
	[SectionPosition(10)] public List<DOC_DocumentMessageDetails> DocumentMessageDetails { get; set; } = new();
	[SectionPosition(11)] public List<SegmentGroup8__SegmentGroup9_SegmentGroup11> SegmentGroup11 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup8__SegmentGroup9_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup8_SegmentGroup9>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.Temperature, 1, 9);
		validator.CollectionSize(x => x.RangeDetails, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.PackageIdentification, 1, 9);
		validator.CollectionSize(x => x.DocumentMessageDetails, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup10, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup11, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup12, 0, 99);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup11) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
