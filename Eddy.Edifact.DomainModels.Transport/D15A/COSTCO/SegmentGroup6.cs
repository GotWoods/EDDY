using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15A;

namespace Eddy.Edifact.DomainModels.Transport.D15A.COSTCO;

public class SegmentGroup6 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(5)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(6)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(7)] public List<EQA_AttachedEquipment> AttachedEquipment { get; set; } = new();
	[SectionPosition(8)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(9)] public List<NAD_NameAndAddress> NameAndAddress { get; set; } = new();
	[SectionPosition(10)] public List<SegmentGroup6_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup6_SegmentGroup9> SegmentGroup9 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.AttachedEquipment, 1, 9);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.NameAndAddress, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup9, 0, 9);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
