using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19A;

namespace Eddy.Edifact.DomainModels.Transport.D19A.IFCSUM;

public class SegmentGroup28_SegmentGroup75 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	[SectionPosition(3)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(4)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(5)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(6)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(7)] public List<TPL_TransportPlacement> TransportPlacement { get; set; } = new();
	[SectionPosition(8)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(9)] public TMP_Temperature Temperature { get; set; } = new();
	[SectionPosition(10)] public RNG_RangeDetails RangeDetails { get; set; } = new();
	[SectionPosition(11)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(12)] public List<PCD_PercentageDetails> PercentageDetails { get; set; } = new();
	[SectionPosition(13)] public List<SegmentGroup28__SegmentGroup75_SegmentGroup76> SegmentGroup76 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup28__SegmentGroup75_SegmentGroup77> SegmentGroup77 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup28__SegmentGroup75_SegmentGroup78> SegmentGroup78 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup28__SegmentGroup75_SegmentGroup79> SegmentGroup79 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28_SegmentGroup75>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.Required(x => x.NumberOfUnits);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 99);
		validator.CollectionSize(x => x.TransportPlacement, 1, 9);
		validator.Required(x => x.HandlingInstructions);
		validator.Required(x => x.Temperature);
		validator.Required(x => x.RangeDetails);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.PercentageDetails, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup76, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup77, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup78, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup79, 0, 99);
		foreach (var item in SegmentGroup76) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup77) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup78) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup79) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
