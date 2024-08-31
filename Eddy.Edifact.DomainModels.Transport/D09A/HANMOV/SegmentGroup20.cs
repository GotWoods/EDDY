using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D09A;

namespace Eddy.Edifact.DomainModels.Transport.D09A.HANMOV;

public class SegmentGroup20 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public List<CST_CustomsStatusOfGoods> CustomsStatusOfGoods { get; set; } = new();
	[SectionPosition(4)] public List<TMP_Temperature> Temperature { get; set; } = new();
	[SectionPosition(5)] public List<RNG_RangeDetails> RangeDetails { get; set; } = new();
	[SectionPosition(6)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(7)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(8)] public List<PIA_AdditionalProductId> AdditionalProductId { get; set; } = new();
	[SectionPosition(9)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(10)] public List<NAD_NameAndAddress> NameAndAddress { get; set; } = new();
	[SectionPosition(11)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(12)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(13)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(14)] public List<PCI_PackageIdentification> PackageIdentification { get; set; } = new();
	[SectionPosition(15)] public List<SegmentGroup20_SegmentGroup21> SegmentGroup21 {get;set;} = new();
	[SectionPosition(16)] public List<SGP_SplitGoodsPlacement> SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(17)] public List<TCC_ChargeRateCalculations> ChargeRateCalculations { get; set; } = new();
	[SectionPosition(18)] public List<SegmentGroup20_SegmentGroup22> SegmentGroup22 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup20>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.CustomsStatusOfGoods, 1, 9);
		validator.CollectionSize(x => x.Temperature, 1, 9);
		validator.CollectionSize(x => x.RangeDetails, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.AdditionalProductId, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.NameAndAddress, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.PackageIdentification, 1, 9);
		validator.CollectionSize(x => x.SplitGoodsPlacement, 1, 9);
		validator.CollectionSize(x => x.ChargeRateCalculations, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup21, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup22, 0, 9);
		foreach (var item in SegmentGroup21) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup22) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
