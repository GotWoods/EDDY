using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D14A;
using Eddy.Edifact.DomainModels.Transport.D14A.IFTFCC;

namespace Eddy.Edifact.DomainModels.Transport.D14A;

public class IFTFCC_InternationalTransportFreightCostsAndOtherCharges {
	[SectionPosition(1)] public UNH_MessageHeader MessageHeader { get; set; } = new();
	[SectionPosition(2)] public BGM_BeginningOfMessage BeginningOfMessage { get; set; } = new();
	[SectionPosition(3)] public CTA_ContactInformation ContactInformation { get; set; } = new();
	[SectionPosition(4)] public List<COM_CommunicationContact> CommunicationContact { get; set; } = new();
	[SectionPosition(5)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(6)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(7)] public List<TSR_TransportServiceRequirements> TransportServiceRequirements { get; set; } = new();
	[SectionPosition(8)] public List<DOC_DocumentMessageDetails> DocumentMessageDetails { get; set; } = new();
	[SectionPosition(9)] public List<SegmentGroup1> SegmentGroup1 {get;set;} = new();
	[SectionPosition(10)] public List<SegmentGroup2> SegmentGroup2 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup3> SegmentGroup3 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup4> SegmentGroup4 {get;set;} = new();
	[SectionPosition(13)] public List<SegmentGroup5> SegmentGroup5 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup6> SegmentGroup6 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup11> SegmentGroup11 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup14> SegmentGroup14 {get;set;} = new();
	[SectionPosition(17)] public List<SegmentGroup15> SegmentGroup15 {get;set;} = new();
	[SectionPosition(18)] public List<SegmentGroup16> SegmentGroup16 {get;set;} = new();
	[SectionPosition(19)] public List<SegmentGroup17> SegmentGroup17 {get;set;} = new();
	[SectionPosition(20)] public List<SegmentGroup19> SegmentGroup19 {get;set;} = new();
	[SectionPosition(21)] public List<SegmentGroup24> SegmentGroup24 {get;set;} = new();
	[SectionPosition(22)] public List<SegmentGroup28> SegmentGroup28 {get;set;} = new();
	[SectionPosition(23)] public UNT_MessageTrailer MessageTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<IFTFCC_InternationalTransportFreightCostsAndOtherCharges>(this);
		validator.Required(x => x.MessageHeader);
		validator.Required(x => x.BeginningOfMessage);
		validator.Required(x => x.ContactInformation);
		validator.CollectionSize(x => x.CommunicationContact, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.TransportServiceRequirements, 1, 9);
		validator.CollectionSize(x => x.DocumentMessageDetails, 1, 9);
		validator.Required(x => x.MessageTrailer);
		

		validator.CollectionSize(x => x.SegmentGroup1, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup2, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup3, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup4, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup5, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup6, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup11, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup14, 0, 5);
		validator.CollectionSize(x => x.SegmentGroup15, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup16, 0, 5);
		validator.CollectionSize(x => x.SegmentGroup17, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup19, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup24, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup28, 0, 99);
		foreach (var item in SegmentGroup1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup2) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup3) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup4) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup5) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup6) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup11) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup14) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup15) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup16) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup17) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup19) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup24) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup28) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
