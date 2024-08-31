using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B;

namespace Eddy.Edifact.DomainModels.Transport.D00B.IFCSUM;

public class SegmentGroup25__SegmentGroup50_SegmentGroup57 {
	[SectionPosition(1)] public GOR_GovernmentalRequirements GovernmentalRequirements { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(4)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(5)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(6)] public List<SegmentGroup25__SegmentGroup50__SegmentGroup57_SegmentGroup58> SegmentGroup58 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup25__SegmentGroup50_SegmentGroup57>(this);
		validator.Required(x => x.GovernmentalRequirements);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup58, 0, 9);
		foreach (var item in SegmentGroup58) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
