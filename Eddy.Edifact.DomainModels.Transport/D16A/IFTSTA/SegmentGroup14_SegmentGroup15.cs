using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D16A;

namespace Eddy.Edifact.DomainModels.Transport.D16A.IFTSTA;

public class SegmentGroup14_SegmentGroup15 {
	[SectionPosition(1)] public STS_Status Status { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public DOC_DocumentMessageDetails DocumentMessageDetails { get; set; } = new();
	[SectionPosition(5)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(6)] public List<SegmentGroup14__SegmentGroup15_SegmentGroup16> SegmentGroup16 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup14__SegmentGroup15_SegmentGroup17> SegmentGroup17 {get;set;} = new();
	[SectionPosition(8)] public LOC_PlaceLocationIdentification PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(9)] public List<PCI_PackageIdentification> PackageIdentification { get; set; } = new();
	[SectionPosition(10)] public List<SegmentGroup14__SegmentGroup15_SegmentGroup19> SegmentGroup19 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup14__SegmentGroup15_SegmentGroup21> SegmentGroup21 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup14__SegmentGroup15_SegmentGroup25> SegmentGroup25 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup14_SegmentGroup15>(this);
		validator.Required(x => x.Status);
		validator.CollectionSize(x => x.Reference, 1, 999);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.Required(x => x.DocumentMessageDetails);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.Required(x => x.PlaceLocationIdentification);
		validator.CollectionSize(x => x.PackageIdentification, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup16, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup17, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup19, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup21, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup25, 0, 9999);
		foreach (var item in SegmentGroup16) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup17) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup19) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup21) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup25) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
