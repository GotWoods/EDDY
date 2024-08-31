using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05A;

namespace Eddy.Edifact.DomainModels.Transport.D05A.IFCSUM;

public class SegmentGroup26 {
	[SectionPosition(1)] public CNI_ConsignmentInformation ConsignmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup26_SegmentGroup27> SegmentGroup27 {get;set;} = new();
	[SectionPosition(3)] public List<SegmentGroup26_SegmentGroup29> SegmentGroup29 {get;set;} = new();
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
	[SectionPosition(14)] public List<SegmentGroup26_SegmentGroup31> SegmentGroup31 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup26_SegmentGroup32> SegmentGroup32 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup26_SegmentGroup33> SegmentGroup33 {get;set;} = new();
	[SectionPosition(17)] public List<SegmentGroup26_SegmentGroup34> SegmentGroup34 {get;set;} = new();
	[SectionPosition(18)] public List<SegmentGroup26_SegmentGroup36> SegmentGroup36 {get;set;} = new();
	[SectionPosition(19)] public List<SegmentGroup26_SegmentGroup37> SegmentGroup37 {get;set;} = new();
	[SectionPosition(20)] public List<SegmentGroup26_SegmentGroup38> SegmentGroup38 {get;set;} = new();
	[SectionPosition(21)] public List<SegmentGroup26_SegmentGroup39> SegmentGroup39 {get;set;} = new();
	[SectionPosition(22)] public List<SegmentGroup26_SegmentGroup44> SegmentGroup44 {get;set;} = new();
	[SectionPosition(23)] public List<SegmentGroup26_SegmentGroup51> SegmentGroup51 {get;set;} = new();
	[SectionPosition(24)] public List<SegmentGroup26_SegmentGroup71> SegmentGroup71 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26>(this);
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
		validator.CollectionSize(x => x.SegmentGroup27, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup29, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup31, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup32, 0, 2);
		validator.CollectionSize(x => x.SegmentGroup33, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup34, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup36, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup37, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup38, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup39, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup44, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup51, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup71, 0, 999);
		foreach (var item in SegmentGroup27) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup29) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup31) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup32) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup33) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup34) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup36) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup37) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup38) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup39) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup44) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup51) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup71) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
