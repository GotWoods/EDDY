using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D02B;

namespace Eddy.Edifact.DomainModels.Transport.D02B.IFTFCC;

public class SegmentGroup28_SegmentGroup37 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public List<TCC_ChargeRateCalculations> ChargeRateCalculations { get; set; } = new();
	[SectionPosition(3)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(4)] public TMP_Temperature Temperature { get; set; } = new();
	[SectionPosition(5)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(6)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(7)] public List<PCI_PackageIdentification> PackageIdentification { get; set; } = new();
	[SectionPosition(8)] public List<PIA_AdditionalProductId> AdditionalProductId { get; set; } = new();
	[SectionPosition(9)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(10)] public List<SegmentGroup28__SegmentGroup37_SegmentGroup38> SegmentGroup38 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup28__SegmentGroup37_SegmentGroup39> SegmentGroup39 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup28__SegmentGroup37_SegmentGroup40> SegmentGroup40 {get;set;} = new();
	[SectionPosition(13)] public List<SegmentGroup28__SegmentGroup37_SegmentGroup41> SegmentGroup41 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28_SegmentGroup37>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.CollectionSize(x => x.ChargeRateCalculations, 1, 99);
		validator.Required(x => x.HandlingInstructions);
		validator.Required(x => x.Temperature);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.PackageIdentification, 1, 9);
		validator.CollectionSize(x => x.AdditionalProductId, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup38, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup39, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup40, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup41, 0, 9);
		foreach (var item in SegmentGroup38) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup39) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup40) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup41) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
