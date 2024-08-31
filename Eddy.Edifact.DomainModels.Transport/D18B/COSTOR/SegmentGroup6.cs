using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D18B;

namespace Eddy.Edifact.DomainModels.Transport.D18B.COSTOR;

public class SegmentGroup6 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(5)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(6)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(7)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(8)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(9)] public List<SegmentGroup6_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	[SectionPosition(10)] public List<SegmentGroup6_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup6_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.Required(x => x.NumberOfUnits);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup10, 0, 9);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
