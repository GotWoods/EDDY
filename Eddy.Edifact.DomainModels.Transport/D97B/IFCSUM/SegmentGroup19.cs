using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B;

namespace Eddy.Edifact.DomainModels.Transport.D97B.IFCSUM;

public class SegmentGroup19 {
	[SectionPosition(1)] public CNI_ConsignmentInformation ConsignmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup19_SegmentGroup20> SegmentGroup20 {get;set;} = new();
	[SectionPosition(3)] public List<SegmentGroup19_SegmentGroup22> SegmentGroup22 {get;set;} = new();
	[SectionPosition(4)] public CTA_ContactInformation ContactInformation { get; set; } = new();
	[SectionPosition(5)] public List<COM_CommunicationContact> CommunicationContact { get; set; } = new();
	[SectionPosition(6)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(7)] public List<CNT_ControlTotal> ControlTotal { get; set; } = new();
	[SectionPosition(8)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(9)] public List<CUX_Currencies> Currencies { get; set; } = new();
	[SectionPosition(10)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(11)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(12)] public List<SegmentGroup19_SegmentGroup24> SegmentGroup24 {get;set;} = new();
	[SectionPosition(13)] public List<SegmentGroup19_SegmentGroup25> SegmentGroup25 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup19_SegmentGroup26> SegmentGroup26 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup19_SegmentGroup27> SegmentGroup27 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup19_SegmentGroup29> SegmentGroup29 {get;set;} = new();
	[SectionPosition(17)] public List<SegmentGroup19_SegmentGroup30> SegmentGroup30 {get;set;} = new();
	[SectionPosition(18)] public List<SegmentGroup19_SegmentGroup31> SegmentGroup31 {get;set;} = new();
	[SectionPosition(19)] public List<SegmentGroup19_SegmentGroup34> SegmentGroup34 {get;set;} = new();
	[SectionPosition(20)] public List<SegmentGroup19_SegmentGroup41> SegmentGroup41 {get;set;} = new();
	[SectionPosition(21)] public List<SegmentGroup19_SegmentGroup60> SegmentGroup60 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19>(this);
		validator.Required(x => x.ConsignmentInformation);
		validator.Required(x => x.ContactInformation);
		validator.CollectionSize(x => x.CommunicationContact, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.ControlTotal, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.Currencies, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 99);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup20, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup22, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup24, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup25, 0, 2);
		validator.CollectionSize(x => x.SegmentGroup26, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup27, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup29, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup30, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup31, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup34, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup41, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup60, 0, 999);
		foreach (var item in SegmentGroup20) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup22) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup24) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup25) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup26) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup27) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup29) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup30) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup31) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup34) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup41) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup60) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
