using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFCSUM;

public class SegmentGroup25 {
	[SectionPosition(1)] public CNI_ConsignmentInformation ConsignmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup25_SegmentGroup26> SegmentGroup26 {get;set;} = new();
	[SectionPosition(3)] public List<SegmentGroup25_SegmentGroup28> SegmentGroup28 {get;set;} = new();
	[SectionPosition(4)] public CTA_ContactInformation ContactInformation { get; set; } = new();
	[SectionPosition(5)] public List<COM_CommunicationContact> CommunicationContact { get; set; } = new();
	[SectionPosition(6)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(7)] public List<CNT_ControlTotal> ControlTotal { get; set; } = new();
	[SectionPosition(8)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(9)] public List<CUX_Currencies> Currencies { get; set; } = new();
	[SectionPosition(10)] public List<PCD_PercentageDetails> PercentageDetails { get; set; } = new();
	[SectionPosition(11)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(12)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(13)] public List<GDS_NatureOfCargo> NatureOfCargo { get; set; } = new();
	[SectionPosition(14)] public List<SegmentGroup25_SegmentGroup30> SegmentGroup30 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup25_SegmentGroup31> SegmentGroup31 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup25_SegmentGroup32> SegmentGroup32 {get;set;} = new();
	[SectionPosition(17)] public List<SegmentGroup25_SegmentGroup33> SegmentGroup33 {get;set;} = new();
	[SectionPosition(18)] public List<SegmentGroup25_SegmentGroup35> SegmentGroup35 {get;set;} = new();
	[SectionPosition(19)] public List<SegmentGroup25_SegmentGroup36> SegmentGroup36 {get;set;} = new();
	[SectionPosition(20)] public List<SegmentGroup25_SegmentGroup37> SegmentGroup37 {get;set;} = new();
	[SectionPosition(21)] public List<SegmentGroup25_SegmentGroup38> SegmentGroup38 {get;set;} = new();
	[SectionPosition(22)] public List<SegmentGroup25_SegmentGroup43> SegmentGroup43 {get;set;} = new();
	[SectionPosition(23)] public List<SegmentGroup25_SegmentGroup50> SegmentGroup50 {get;set;} = new();
	[SectionPosition(24)] public List<SegmentGroup25_SegmentGroup70> SegmentGroup70 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup25>(this);
		validator.Required(x => x.ConsignmentInformation);
		validator.Required(x => x.ContactInformation);
		validator.CollectionSize(x => x.CommunicationContact, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.ControlTotal, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.Currencies, 1, 9);
		validator.CollectionSize(x => x.PercentageDetails, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 99);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.NatureOfCargo, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup26, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup28, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup30, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup31, 0, 2);
		validator.CollectionSize(x => x.SegmentGroup32, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup33, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup35, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup36, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup37, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup38, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup43, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup50, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup70, 0, 999);
		foreach (var item in SegmentGroup26) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup28) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup30) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup31) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup32) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup33) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup35) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup36) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup37) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup38) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup43) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup50) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup70) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
