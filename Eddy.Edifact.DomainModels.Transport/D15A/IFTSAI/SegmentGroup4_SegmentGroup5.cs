using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15A;

namespace Eddy.Edifact.DomainModels.Transport.D15A.IFTSAI;

public class SegmentGroup4_SegmentGroup5 {
	[SectionPosition(1)] public LOC_PlaceLocationIdentification PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup4__SegmentGroup5_SegmentGroup6> SegmentGroup6 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup4__SegmentGroup5_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup4__SegmentGroup5_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	[SectionPosition(7)] public CNT_ControlTotal ControlTotal { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4_SegmentGroup5>(this);
		validator.Required(x => x.PlaceLocationIdentification);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.Required(x => x.ControlTotal);
		validator.CollectionSize(x => x.SegmentGroup6, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 9);
		foreach (var item in SegmentGroup6) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
