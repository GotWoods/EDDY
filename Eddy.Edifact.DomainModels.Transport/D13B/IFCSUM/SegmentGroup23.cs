using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D13B;

namespace Eddy.Edifact.DomainModels.Transport.D13B.IFCSUM;

public class SegmentGroup23 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	[SectionPosition(3)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(4)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(5)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(6)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(7)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(8)] public List<NAD_NameAndAddress> NameAndAddress { get; set; } = new();
	[SectionPosition(9)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(10)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(11)] public TMP_Temperature Temperature { get; set; } = new();
	[SectionPosition(12)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(13)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(14)] public List<PCD_PercentageDetails> PercentageDetails { get; set; } = new();
	[SectionPosition(15)] public List<SegmentGroup23_SegmentGroup24> SegmentGroup24 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup23_SegmentGroup25> SegmentGroup25 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup23>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.Required(x => x.NumberOfUnits);
		validator.Required(x => x.TransportPlacement);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.NameAndAddress, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.Required(x => x.HandlingInstructions);
		validator.Required(x => x.Temperature);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.PercentageDetails, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup24, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup25, 0, 99);
		foreach (var item in SegmentGroup24) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup25) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
