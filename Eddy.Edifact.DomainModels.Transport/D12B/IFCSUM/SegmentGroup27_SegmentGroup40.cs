using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D12B;

namespace Eddy.Edifact.DomainModels.Transport.D12B.IFCSUM;

public class SegmentGroup27_SegmentGroup40 {
	[SectionPosition(1)] public TDT_TransportInformation TransportInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup27__SegmentGroup40_SegmentGroup41> SegmentGroup41 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup27__SegmentGroup40_SegmentGroup42> SegmentGroup42 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup27__SegmentGroup40_SegmentGroup43> SegmentGroup43 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup27__SegmentGroup40_SegmentGroup44> SegmentGroup44 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup27__SegmentGroup40_SegmentGroup45> SegmentGroup45 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup27_SegmentGroup40>(this);
		validator.Required(x => x.TransportInformation);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup41, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup42, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup43, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup44, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup45, 0, 99);
		foreach (var item in SegmentGroup41) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup42) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup43) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup44) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup45) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
