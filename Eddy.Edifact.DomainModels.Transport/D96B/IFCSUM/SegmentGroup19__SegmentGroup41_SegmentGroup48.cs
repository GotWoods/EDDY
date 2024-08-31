using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B;

namespace Eddy.Edifact.DomainModels.Transport.D96B.IFCSUM;

public class SegmentGroup19__SegmentGroup41_SegmentGroup48 {
	[SectionPosition(1)] public GOR_GovernmentalRequirements GovernmentalRequirements { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(4)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(5)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(6)] public List<SegmentGroup19__SegmentGroup41__SegmentGroup48_SegmentGroup49> SegmentGroup49 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup41_SegmentGroup48>(this);
		validator.Required(x => x.GovernmentalRequirements);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup49, 0, 9);
		foreach (var item in SegmentGroup49) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
