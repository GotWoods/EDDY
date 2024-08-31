using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A;

namespace Eddy.Edifact.DomainModels.Transport.D00A.IFCSUM;

public class SegmentGroup25_SegmentGroup43 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup25__SegmentGroup43_SegmentGroup44> SegmentGroup44 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup25__SegmentGroup43_SegmentGroup45> SegmentGroup45 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup25__SegmentGroup43_SegmentGroup46> SegmentGroup46 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup25__SegmentGroup43_SegmentGroup47> SegmentGroup47 {get;set;} = new();
	[SectionPosition(8)] public List<SegmentGroup25__SegmentGroup43_SegmentGroup48> SegmentGroup48 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup25__SegmentGroup43_SegmentGroup49> SegmentGroup49 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup25_SegmentGroup43>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup44, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup45, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup46, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup47, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup48, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup49, 0, 99);
		foreach (var item in SegmentGroup44) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup45) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup46) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup47) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup48) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup49) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
