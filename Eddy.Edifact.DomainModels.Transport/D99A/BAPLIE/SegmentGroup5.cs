using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A;

namespace Eddy.Edifact.DomainModels.Transport.D99A.BAPLIE;

public class SegmentGroup5 {
	[SectionPosition(1)] public LOC_PlaceLocationIdentification PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(2)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(3)] public GDS_NatureOfCargo NatureOfCargo { get; set; } = new();
	[SectionPosition(4)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(5)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(6)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(7)] public TMP_Temperature Temperature { get; set; } = new();
	[SectionPosition(8)] public RNG_RangeDetails RangeDetails { get; set; } = new();
	[SectionPosition(9)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification2 { get; set; } = new();
	[SectionPosition(10)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(11)] public List<SegmentGroup5_SegmentGroup6> SegmentGroup6 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup5_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup5>(this);
		validator.Required(x => x.PlaceLocationIdentification);
		validator.Required(x => x.GoodsItemDetails);
		validator.Required(x => x.NatureOfCargo);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.Required(x => x.Temperature);
		validator.Required(x => x.RangeDetails);
		validator.CollectionSize(x => x.PlaceLocationIdentification2, 1, 9);
		validator.Required(x => x.Reference);
		validator.CollectionSize(x => x.SegmentGroup6, 0, 3);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 999);
		foreach (var item in SegmentGroup6) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
