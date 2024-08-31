using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFCSUM;

public class SegmentGroup15 {
	[SectionPosition(1)] public CNI_ConsignmentInformation ConsignmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup15_SegmentGroup16> SegmentGroup16 {get;set;} = new();
	[SectionPosition(3)] public List<SegmentGroup15_SegmentGroup18> SegmentGroup18 {get;set;} = new();
	[SectionPosition(4)] public CTA_ContactInformation ContactInformation { get; set; } = new();
	[SectionPosition(5)] public List<COM_CommunicationContact> CommunicationContact { get; set; } = new();
	[SectionPosition(6)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(7)] public List<CNT_ControlTotal> ControlTotal { get; set; } = new();
	[SectionPosition(8)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(9)] public List<CUX_Currencies> Currencies { get; set; } = new();
	[SectionPosition(10)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(11)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(12)] public List<SegmentGroup15_SegmentGroup20> SegmentGroup20 {get;set;} = new();
	[SectionPosition(13)] public List<SegmentGroup15_SegmentGroup21> SegmentGroup21 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup15_SegmentGroup22> SegmentGroup22 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup15_SegmentGroup23> SegmentGroup23 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup15_SegmentGroup25> SegmentGroup25 {get;set;} = new();
	[SectionPosition(17)] public List<SegmentGroup15_SegmentGroup26> SegmentGroup26 {get;set;} = new();
	[SectionPosition(18)] public List<SegmentGroup15_SegmentGroup27> SegmentGroup27 {get;set;} = new();
	[SectionPosition(19)] public List<SegmentGroup15_SegmentGroup30> SegmentGroup30 {get;set;} = new();
	[SectionPosition(20)] public List<SegmentGroup15_SegmentGroup37> SegmentGroup37 {get;set;} = new();
	[SectionPosition(21)] public List<SegmentGroup15_SegmentGroup56> SegmentGroup56 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup15>(this);
		validator.Required(x => x.ConsignmentInformation);
		validator.Required(x => x.ContactInformation);
		validator.CollectionSize(x => x.CommunicationContact, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.ControlTotal, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.Currencies, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 99);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup16, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup18, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup20, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup21, 0, 2);
		validator.CollectionSize(x => x.SegmentGroup22, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup23, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup25, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup26, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup27, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup30, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup37, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup56, 0, 999);
		foreach (var item in SegmentGroup16) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup18) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup20) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup21) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup22) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup23) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup25) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup26) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup27) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup30) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup37) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup56) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
