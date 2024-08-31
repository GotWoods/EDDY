using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C;

namespace Eddy.Edifact.DomainModels.Transport.D01C.IFTSTQ;

public class SegmentGroup4 {
	[SectionPosition(1)] public CNI_ConsignmentInformation ConsignmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(4)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(5)] public List<TDT_DetailsOfTransport> DetailsOfTransport { get; set; } = new();
	[SectionPosition(6)] public List<SegmentGroup4_SegmentGroup5> SegmentGroup5 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup4_SegmentGroup6> SegmentGroup6 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4>(this);
		validator.Required(x => x.ConsignmentInformation);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 99);
		validator.CollectionSize(x => x.Reference, 1, 99);
		validator.CollectionSize(x => x.DetailsOfTransport, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup5, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup6, 0, 9);
		foreach (var item in SegmentGroup5) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup6) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
