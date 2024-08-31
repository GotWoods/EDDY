using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D13B;

namespace Eddy.Edifact.DomainModels.Transport.D13B.COPRAR;

public class SegmentGroup6 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	[SectionPosition(4)] public List<TMD_TransportMovementDetails> TransportMovementDetails { get; set; } = new();
	[SectionPosition(5)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(6)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(7)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(8)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(9)] public List<SegmentGroup6_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	[SectionPosition(10)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(11)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(12)] public List<PCD_PercentageDetails> PercentageDetails { get; set; } = new();
	[SectionPosition(13)] public List<SegmentGroup6_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	[SectionPosition(14)] public List<EQA_AttachedEquipment> AttachedEquipment { get; set; } = new();
	[SectionPosition(15)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(16)] public List<SegmentGroup6_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	[SectionPosition(17)] public List<NAD_NameAndAddress> NameAndAddress { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.Required(x => x.NumberOfUnits);
		validator.CollectionSize(x => x.TransportMovementDetails, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.PercentageDetails, 1, 9);
		validator.CollectionSize(x => x.AttachedEquipment, 1, 9);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.NameAndAddress, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 99);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
