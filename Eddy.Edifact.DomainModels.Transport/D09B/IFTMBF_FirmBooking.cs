using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D09B;
using Eddy.Edifact.DomainModels.Transport.D09B.IFTMBF;

namespace Eddy.Edifact.DomainModels.Transport.D09B;

public class IFTMBF_FirmBooking {
	[SectionPosition(1)] public UNH_MessageHeader MessageHeader { get; set; } = new();
	[SectionPosition(2)] public BGM_BeginningOfMessage BeginningOfMessage { get; set; } = new();
	[SectionPosition(3)] public CTA_ContactInformation ContactInformation { get; set; } = new();
	[SectionPosition(4)] public List<COM_CommunicationContact> CommunicationContact { get; set; } = new();
	[SectionPosition(5)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(6)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(7)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(8)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(9)] public List<CNT_ControlTotal> ControlTotal { get; set; } = new();
	[SectionPosition(10)] public List<GDS_NatureOfCargo> NatureOfCargo { get; set; } = new();
	[SectionPosition(11)] public List<SegmentGroup1> SegmentGroup1 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup2> SegmentGroup2 {get;set;} = new();
	[SectionPosition(13)] public List<SegmentGroup3> SegmentGroup3 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup4> SegmentGroup4 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup6> SegmentGroup6 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup7> SegmentGroup7 {get;set;} = new();
	[SectionPosition(17)] public List<SegmentGroup10> SegmentGroup10 {get;set;} = new();
	[SectionPosition(18)] public List<SegmentGroup16> SegmentGroup16 {get;set;} = new();
	[SectionPosition(19)] public List<SegmentGroup32> SegmentGroup32 {get;set;} = new();
	[SectionPosition(20)] public UNT_MessageTrailer MessageTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<IFTMBF_FirmBooking>(this);
		validator.Required(x => x.MessageHeader);
		validator.Required(x => x.BeginningOfMessage);
		validator.Required(x => x.ContactInformation);
		validator.CollectionSize(x => x.CommunicationContact, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.ControlTotal, 1, 9);
		validator.CollectionSize(x => x.NatureOfCargo, 1, 9);
		validator.Required(x => x.MessageTrailer);
		

		validator.CollectionSize(x => x.SegmentGroup1, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup2, 0, 2);
		validator.CollectionSize(x => x.SegmentGroup3, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup4, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup6, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup10, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup16, 0, 99999);
		validator.CollectionSize(x => x.SegmentGroup32, 0, 999);
		foreach (var item in SegmentGroup1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup2) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup3) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup4) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup6) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup16) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup32) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
