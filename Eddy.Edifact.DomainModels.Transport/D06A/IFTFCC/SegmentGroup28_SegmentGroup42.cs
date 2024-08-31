using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D06A;

namespace Eddy.Edifact.DomainModels.Transport.D06A.IFTFCC;

public class SegmentGroup28_SegmentGroup42 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<TCC_ChargeRateCalculations> ChargeRateCalculations { get; set; } = new();
	[SectionPosition(3)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	[SectionPosition(4)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(5)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(6)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(7)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(8)] public List<TPL_TransportPlacement> TransportPlacement { get; set; } = new();
	[SectionPosition(9)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(10)] public List<SegmentGroup28__SegmentGroup42_SegmentGroup43> SegmentGroup43 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup28__SegmentGroup42_SegmentGroup44> SegmentGroup44 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup28__SegmentGroup42_SegmentGroup45> SegmentGroup45 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28_SegmentGroup42>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.ChargeRateCalculations, 1, 99);
		validator.Required(x => x.NumberOfUnits);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 99);
		validator.CollectionSize(x => x.TransportPlacement, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup43, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup44, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup45, 0, 99);
		foreach (var item in SegmentGroup43) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup44) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup45) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
