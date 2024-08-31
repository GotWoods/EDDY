using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05A;

namespace Eddy.Edifact.DomainModels.Transport.D05A.IFTFCC;

public class SegmentGroup28 {
	[SectionPosition(1)] public CNI_ConsignmentInformation ConsignmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<TCC_ChargeRateCalculations> ChargeRateCalculations { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(4)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(5)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(6)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(7)] public List<SegmentGroup28_SegmentGroup29> SegmentGroup29 {get;set;} = new();
	[SectionPosition(8)] public List<SegmentGroup28_SegmentGroup30> SegmentGroup30 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup28_SegmentGroup31> SegmentGroup31 {get;set;} = new();
	[SectionPosition(10)] public List<SegmentGroup28_SegmentGroup32> SegmentGroup32 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup28_SegmentGroup33> SegmentGroup33 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup28_SegmentGroup34> SegmentGroup34 {get;set;} = new();
	[SectionPosition(13)] public List<SegmentGroup28_SegmentGroup35> SegmentGroup35 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup28_SegmentGroup37> SegmentGroup37 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup28_SegmentGroup42> SegmentGroup42 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28>(this);
		validator.Required(x => x.ConsignmentInformation);
		validator.CollectionSize(x => x.ChargeRateCalculations, 1, 99);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup29, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup30, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup31, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup32, 0, 5);
		validator.CollectionSize(x => x.SegmentGroup33, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup34, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup35, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup37, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup42, 0, 999);
		foreach (var item in SegmentGroup29) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup30) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup31) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup32) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup33) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup34) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup35) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup37) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup42) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
