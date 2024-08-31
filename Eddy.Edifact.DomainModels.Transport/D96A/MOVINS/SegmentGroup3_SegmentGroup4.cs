using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.MOVINS;

public class SegmentGroup3_SegmentGroup4 {
	[SectionPosition(1)] public LOC_PlaceLocationIdentification PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(4)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(5)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(6)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification2 { get; set; } = new();
	[SectionPosition(7)] public List<NAD_NameAndAddress> NameAndAddress { get; set; } = new();
	[SectionPosition(8)] public List<SegmentGroup3__SegmentGroup4_SegmentGroup5> SegmentGroup5 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup3__SegmentGroup4_SegmentGroup6> SegmentGroup6 {get;set;} = new();
	[SectionPosition(10)] public List<SegmentGroup3__SegmentGroup4_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup3__SegmentGroup4_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup3__SegmentGroup4_SegmentGroup9> SegmentGroup9 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3_SegmentGroup4>(this);
		validator.Required(x => x.PlaceLocationIdentification);
		validator.CollectionSize(x => x.Reference, 1, 99);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification2, 1, 9);
		validator.CollectionSize(x => x.NameAndAddress, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup6, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 9999);
		validator.CollectionSize(x => x.SegmentGroup9, 0, 999);
		foreach (var item in SegmentGroup5) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup6) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
