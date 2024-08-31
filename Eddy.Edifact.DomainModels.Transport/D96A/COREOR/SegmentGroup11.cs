using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.COREOR;

public class SegmentGroup11 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(4)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(5)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(6)] public List<TMP_Temperature> Temperature { get; set; } = new();
	[SectionPosition(7)] public List<RNG_RangeDetails> RangeDetails { get; set; } = new();
	[SectionPosition(8)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(9)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(10)] public List<PCD_PercentageDetails> PercentageDetails { get; set; } = new();
	[SectionPosition(11)] public EQA_AttachedEquipment AttachedEquipment { get; set; } = new();
	[SectionPosition(12)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(13)] public List<SegmentGroup11_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup11_SegmentGroup13> SegmentGroup13 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup11_SegmentGroup14> SegmentGroup14 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup11_SegmentGroup15> SegmentGroup15 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup11>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.Temperature, 1, 9);
		validator.CollectionSize(x => x.RangeDetails, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.PercentageDetails, 1, 9);
		validator.Required(x => x.AttachedEquipment);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup12, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup13, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup14, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup15, 0, 99);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup13) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup14) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup15) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
