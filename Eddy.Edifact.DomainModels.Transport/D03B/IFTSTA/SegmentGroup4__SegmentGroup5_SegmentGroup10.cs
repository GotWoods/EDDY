using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D03B;

namespace Eddy.Edifact.DomainModels.Transport.D03B.IFTSTA;

public class SegmentGroup4__SegmentGroup5_SegmentGroup10 {
	[SectionPosition(1)] public EQD_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(3)] public List<DIM_Dimensions> Dimensions { get; set; } = new();
	[SectionPosition(4)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(5)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(6)] public List<TPL_TransportPlacement> TransportPlacement { get; set; } = new();
	[SectionPosition(7)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(8)] public List<SegmentGroup4__SegmentGroup5__SegmentGroup10_SegmentGroup11> SegmentGroup11 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup4__SegmentGroup5__SegmentGroup10_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4__SegmentGroup5_SegmentGroup10>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Dimensions, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.TransportPlacement, 1, 9);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.SegmentGroup11, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup12, 0, 99);
		foreach (var item in SegmentGroup11) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
