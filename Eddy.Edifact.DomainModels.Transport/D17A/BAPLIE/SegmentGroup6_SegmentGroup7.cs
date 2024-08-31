using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D17A;

namespace Eddy.Edifact.DomainModels.Transport.D17A.BAPLIE;

public class SegmentGroup6_SegmentGroup7 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<NAD_NameAndAddress> NameAndAddress { get; set; } = new();
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(4)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(5)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(6)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(7)] public List<GDS_NatureOfCargo> NatureOfCargo { get; set; } = new();
	[SectionPosition(8)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(9)] public List<SegmentGroup6__SegmentGroup7_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	[SectionPosition(10)] public List<SegmentGroup6__SegmentGroup7_SegmentGroup9> SegmentGroup9 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup6__SegmentGroup7_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup6__SegmentGroup7_SegmentGroup11> SegmentGroup11 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6_SegmentGroup7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.NameAndAddress, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 99);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.NatureOfCargo, 1, 99);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup9, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup10, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup11, 0, 999);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup9) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup11) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
