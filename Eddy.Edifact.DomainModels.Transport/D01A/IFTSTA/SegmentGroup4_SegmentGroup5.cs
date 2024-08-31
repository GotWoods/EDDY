using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01A;

namespace Eddy.Edifact.DomainModels.Transport.D01A.IFTSTA;

public class SegmentGroup4_SegmentGroup5 {
	[SectionPosition(1)] public STS_Status Status { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public DOC_DocumentMessageDetails DocumentMessageDetails { get; set; } = new();
	[SectionPosition(5)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(6)] public List<SegmentGroup4__SegmentGroup5_SegmentGroup6> SegmentGroup6 {get;set;} = new();
	[SectionPosition(7)] public LOC_PlaceLocationIdentification PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(8)] public List<PCI_PackageIdentification> PackageIdentification { get; set; } = new();
	[SectionPosition(9)] public List<SegmentGroup4__SegmentGroup5_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	[SectionPosition(10)] public List<SegmentGroup4__SegmentGroup5_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup4__SegmentGroup5_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4_SegmentGroup5>(this);
		validator.Required(x => x.Status);
		validator.CollectionSize(x => x.Reference, 1, 999);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.Required(x => x.DocumentMessageDetails);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.Required(x => x.PlaceLocationIdentification);
		validator.CollectionSize(x => x.PackageIdentification, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup6, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup10, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup12, 0, 99);
		foreach (var item in SegmentGroup6) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
