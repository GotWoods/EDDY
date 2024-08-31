using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15A;

namespace Eddy.Edifact.DomainModels.Transport.D15A.IFTSTA;

public class SegmentGroup13_SegmentGroup14 {
	[SectionPosition(1)] public STS_Status Status { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public DOC_DocumentMessageDetails DocumentMessageDetails { get; set; } = new();
	[SectionPosition(5)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(6)] public List<SegmentGroup13__SegmentGroup14_SegmentGroup15> SegmentGroup15 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup13__SegmentGroup14_SegmentGroup16> SegmentGroup16 {get;set;} = new();
	[SectionPosition(8)] public LOC_PlaceLocationIdentification PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(9)] public List<PCI_PackageIdentification> PackageIdentification { get; set; } = new();
	[SectionPosition(10)] public List<SegmentGroup13__SegmentGroup14_SegmentGroup18> SegmentGroup18 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup13__SegmentGroup14_SegmentGroup20> SegmentGroup20 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup13__SegmentGroup14_SegmentGroup24> SegmentGroup24 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup13_SegmentGroup14>(this);
		validator.Required(x => x.Status);
		validator.CollectionSize(x => x.Reference, 1, 999);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.Required(x => x.DocumentMessageDetails);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.Required(x => x.PlaceLocationIdentification);
		validator.CollectionSize(x => x.PackageIdentification, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup15, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup16, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup18, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup20, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup24, 0, 9999);
		foreach (var item in SegmentGroup15) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup16) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup18) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup20) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup24) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
