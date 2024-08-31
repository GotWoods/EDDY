using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D16B;

namespace Eddy.Edifact.DomainModels.Transport.D16B.IFCSUM;

public class SegmentGroup9 {
	[SectionPosition(1)] public TDT_TransportInformation TransportInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup9_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup9_SegmentGroup11> SegmentGroup11 {get;set;} = new();
	[SectionPosition(5)] public List<SEL_SealNumber> SealNumber { get; set; } = new();
	[SectionPosition(6)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(7)] public List<SegmentGroup9_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	[SectionPosition(8)] public List<SegmentGroup9_SegmentGroup13> SegmentGroup13 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup9_SegmentGroup14> SegmentGroup14 {get;set;} = new();
	[SectionPosition(10)] public List<SegmentGroup9_SegmentGroup15> SegmentGroup15 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup9_SegmentGroup16> SegmentGroup16 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup9_SegmentGroup17> SegmentGroup17 {get;set;} = new();
	[SectionPosition(13)] public List<SegmentGroup9_SegmentGroup18> SegmentGroup18 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9>(this);
		validator.Required(x => x.TransportInformation);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.SealNumber, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup10, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup11, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup12, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup13, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup14, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup15, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup16, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup17, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup18, 0, 9);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup11) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup13) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup14) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup15) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup16) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup17) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup18) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
