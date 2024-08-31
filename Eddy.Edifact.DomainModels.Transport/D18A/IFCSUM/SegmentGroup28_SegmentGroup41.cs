using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D18A;

namespace Eddy.Edifact.DomainModels.Transport.D18A.IFCSUM;

public class SegmentGroup28_SegmentGroup41 {
	[SectionPosition(1)] public TDT_TransportInformation TransportInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup28__SegmentGroup41_SegmentGroup42> SegmentGroup42 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup28__SegmentGroup41_SegmentGroup43> SegmentGroup43 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup28__SegmentGroup41_SegmentGroup44> SegmentGroup44 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup28__SegmentGroup41_SegmentGroup45> SegmentGroup45 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup28__SegmentGroup41_SegmentGroup46> SegmentGroup46 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28_SegmentGroup41>(this);
		validator.Required(x => x.TransportInformation);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup42, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup43, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup44, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup45, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup46, 0, 99);
		foreach (var item in SegmentGroup42) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup43) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup44) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup45) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup46) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
