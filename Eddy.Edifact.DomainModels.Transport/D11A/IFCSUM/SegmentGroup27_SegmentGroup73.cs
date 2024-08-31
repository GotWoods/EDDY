using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D11A;

namespace Eddy.Edifact.DomainModels.Transport.D11A.IFCSUM;

public class SegmentGroup27_SegmentGroup73 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	[SectionPosition(3)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(4)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(5)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(6)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(7)] public List<TPL_TransportPlacement> TransportPlacement { get; set; } = new();
	[SectionPosition(8)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(9)] public TMP_Temperature Temperature { get; set; } = new();
	[SectionPosition(10)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(11)] public List<PCD_PercentageDetails> PercentageDetails { get; set; } = new();
	[SectionPosition(12)] public List<SegmentGroup27__SegmentGroup73_SegmentGroup74> SegmentGroup74 {get;set;} = new();
	[SectionPosition(13)] public List<SegmentGroup27__SegmentGroup73_SegmentGroup75> SegmentGroup75 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup27__SegmentGroup73_SegmentGroup76> SegmentGroup76 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup27__SegmentGroup73_SegmentGroup77> SegmentGroup77 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup27_SegmentGroup73>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.Required(x => x.NumberOfUnits);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 99);
		validator.CollectionSize(x => x.TransportPlacement, 1, 9);
		validator.Required(x => x.HandlingInstructions);
		validator.Required(x => x.Temperature);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.PercentageDetails, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup74, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup75, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup76, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup77, 0, 99);
		foreach (var item in SegmentGroup74) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup75) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup76) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup77) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
