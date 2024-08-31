using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D20B;

namespace Eddy.Edifact.DomainModels.Transport.D20B.IFTSTA;

public class SegmentGroup5 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(3)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(4)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(5)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(6)] public List<TPL_TransportPlacement> TransportPlacement { get; set; } = new();
	[SectionPosition(7)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(8)] public List<SegmentGroup5_SegmentGroup6> SegmentGroup6 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup5_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	[SectionPosition(10)] public List<SegmentGroup5_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup5_SegmentGroup9> SegmentGroup9 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup5_SegmentGroup11> SegmentGroup11 {get;set;} = new();
	[SectionPosition(13)] public List<SegmentGroup5_SegmentGroup13> SegmentGroup13 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup5_SegmentGroup14> SegmentGroup14 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup5>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.TransportPlacement, 1, 9);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.SegmentGroup6, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup9, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup11, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup14, 0, 9);
		foreach (var item in SegmentGroup6) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup9) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup11) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup13) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup14) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
