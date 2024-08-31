using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D10A;

namespace Eddy.Edifact.DomainModels.Transport.D10A.COPARN;

public class SegmentGroup13 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	[SectionPosition(4)] public List<TMD_TransportMovementDetails> TransportMovementDetails { get; set; } = new();
	[SectionPosition(5)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(6)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(7)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(8)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(9)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(10)] public List<SegmentGroup13_SegmentGroup14> SegmentGroup14 {get;set;} = new();
	[SectionPosition(11)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(12)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(13)] public List<PCD_PercentageDetails> PercentageDetails { get; set; } = new();
	[SectionPosition(14)] public List<SegmentGroup13_SegmentGroup15> SegmentGroup15 {get;set;} = new();
	[SectionPosition(15)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(16)] public List<GOR_GovernmentalRequirements> GovernmentalRequirements { get; set; } = new();
	[SectionPosition(17)] public EQA_AttachedEquipment AttachedEquipment { get; set; } = new();
	[SectionPosition(18)] public COD_ComponentDetails ComponentDetails { get; set; } = new();
	[SectionPosition(19)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(20)] public List<SegmentGroup13_SegmentGroup17> SegmentGroup17 {get;set;} = new();
	[SectionPosition(21)] public List<SegmentGroup13_SegmentGroup18> SegmentGroup18 {get;set;} = new();
	[SectionPosition(22)] public List<SegmentGroup13_SegmentGroup20> SegmentGroup20 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup13>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.Required(x => x.NumberOfUnits);
		validator.CollectionSize(x => x.TransportMovementDetails, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.PercentageDetails, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.GovernmentalRequirements, 1, 9);
		validator.Required(x => x.AttachedEquipment);
		validator.Required(x => x.ComponentDetails);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup14, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup15, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup17, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup18, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup20, 0, 9);
		foreach (var item in SegmentGroup14) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup15) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup17) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup18) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup20) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
