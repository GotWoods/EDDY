using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B;

namespace Eddy.Edifact.DomainModels.Transport.D96B.IFTFCC;

public class SegmentGroup24 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<TCC_TransportChargeRateCalculations> TransportChargeRateCalculations { get; set; } = new();
	[SectionPosition(3)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	[SectionPosition(4)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(5)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(6)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(7)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(8)] public List<TPL_TransportPlacement> TransportPlacement { get; set; } = new();
	[SectionPosition(9)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(10)] public List<SegmentGroup24_SegmentGroup25> SegmentGroup25 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup24_SegmentGroup26> SegmentGroup26 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup24_SegmentGroup27> SegmentGroup27 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup24>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.TransportChargeRateCalculations, 1, 99);
		validator.Required(x => x.NumberOfUnits);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 99);
		validator.CollectionSize(x => x.TransportPlacement, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup25, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup26, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup27, 0, 99);
		foreach (var item in SegmentGroup25) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup26) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup27) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
