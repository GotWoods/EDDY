using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19B;

namespace Eddy.Edifact.DomainModels.Transport.D19B.IFTSTA;

public class SegmentGroup4 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<NAD_NameAndAddress> NameAndAddress { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(5)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(6)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(7)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(8)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(9)] public List<TPL_TransportPlacement> TransportPlacement { get; set; } = new();
	[SectionPosition(10)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(11)] public List<SegmentGroup4_SegmentGroup5> SegmentGroup5 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup4_SegmentGroup6> SegmentGroup6 {get;set;} = new();
	[SectionPosition(13)] public List<SegmentGroup4_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup4_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup4_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup4_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	[SectionPosition(17)] public List<SegmentGroup4_SegmentGroup13> SegmentGroup13 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.NameAndAddress, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 999);
		validator.CollectionSize(x => x.TransportPlacement, 1, 9);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.SegmentGroup5, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup6, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup10, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup13, 0, 9);
		foreach (var item in SegmentGroup5) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup6) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup13) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
