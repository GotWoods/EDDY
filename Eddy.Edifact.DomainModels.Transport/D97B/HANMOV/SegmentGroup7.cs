using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B;

namespace Eddy.Edifact.DomainModels.Transport.D97B.HANMOV;

public class SegmentGroup7 {
	[SectionPosition(1)] public LIN_LineItem LineItem { get; set; } = new();
	[SectionPosition(2)] public List<PIA_AdditionalProductId> AdditionalProductId { get; set; } = new();
	[SectionPosition(3)] public List<IMD_ItemDescription> ItemDescription { get; set; } = new();
	[SectionPosition(4)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(5)] public List<TCC_TransportChargeRateCalculations> TransportChargeRateCalculations { get; set; } = new();
	[SectionPosition(6)] public List<SegmentGroup7_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	[SectionPosition(7)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(8)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(9)] public List<GIN_GoodsIdentityNumber> GoodsIdentityNumber { get; set; } = new();
	[SectionPosition(10)] public List<GIR_RelatedIdentificationNumbers> RelatedIdentificationNumbers { get; set; } = new();
	[SectionPosition(11)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(12)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(13)] public List<SegmentGroup7_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	[SectionPosition(14)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(15)] public List<SegmentGroup7_SegmentGroup11> SegmentGroup11 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup7>(this);
		validator.Required(x => x.LineItem);
		validator.CollectionSize(x => x.AdditionalProductId, 1, 9);
		validator.CollectionSize(x => x.ItemDescription, 1, 99);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.TransportChargeRateCalculations, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Quantity, 1, 9);
		validator.CollectionSize(x => x.GoodsIdentityNumber, 1, 99);
		validator.CollectionSize(x => x.RelatedIdentificationNumbers, 1, 99);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup10, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup11, 0, 99);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup11) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
