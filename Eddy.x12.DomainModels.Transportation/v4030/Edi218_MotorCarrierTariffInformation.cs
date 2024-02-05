using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;
using Eddy.x12.DomainModels.Transportation.v4030._218;

namespace Eddy.x12.DomainModels.Transportation.v4030;

public class Edi218_MotorCarrierTariffInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public TF_TariffInformation TariffInformation { get; set; } = new();
	[SectionPosition(3)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(4)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(5)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(6)] public List<L2000> L2000 {get;set;} = new();

	//Details
	[SectionPosition(7)] public LS_LoopHeader? LoopHeader1 { get; set; }
	[SectionPosition(8)] public List<L2100> L21001 {get;set;} = new();
	[SectionPosition(9)] public LE_LoopTrailer? LoopTrailer1 { get; set; }
	[SectionPosition(10)] public LS_LoopHeader? LoopHeader2 { get; set; }
	[SectionPosition(11)] public List<L2200> L22002 {get;set;} = new();
	[SectionPosition(12)] public LE_LoopTrailer? LoopTrailer2 { get; set; }
	[SectionPosition(13)] public LS_LoopHeader? LoopHeader3 { get; set; }
	[SectionPosition(14)] public List<L2300> L23003 {get;set;} = new();
	[SectionPosition(15)] public LE_LoopTrailer? LoopTrailer3 { get; set; }
	[SectionPosition(16)] public LS_LoopHeader? LoopHeader4 { get; set; }
	[SectionPosition(17)] public List<L2400> L24004 {get;set;} = new();
	[SectionPosition(18)] public LE_LoopTrailer? LoopTrailer4 { get; set; }
	[SectionPosition(19)] public LS_LoopHeader? LoopHeader5 { get; set; }
	[SectionPosition(20)] public List<L2500> L25005 {get;set;} = new();
	[SectionPosition(21)] public LE_LoopTrailer? LoopTrailer5 { get; set; }
	[SectionPosition(22)] public LS_LoopHeader? LoopHeader6 { get; set; }
	[SectionPosition(23)] public List<L2600> L26006 {get;set;} = new();
	[SectionPosition(24)] public LE_LoopTrailer? LoopTrailer6 { get; set; }
	[SectionPosition(25)] public LS_LoopHeader? LoopHeader7 { get; set; }
	[SectionPosition(26)] public List<L2700> L27007 {get;set;} = new();
	[SectionPosition(27)] public LE_LoopTrailer? LoopTrailer7 { get; set; }
	[SectionPosition(28)] public LS_LoopHeader? LoopHeader8 { get; set; }
	[SectionPosition(29)] public List<L2800> L28008 {get;set;} = new();
	[SectionPosition(30)] public LE_LoopTrailer? LoopTrailer8 { get; set; }

	//Summary
	[SectionPosition(31)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi218_MotorCarrierTariffInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TariffInformation);
		validator.CollectionSize(x => x.DateTime, 0, 5);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 10);
		

		validator.CollectionSize(x => x.L0100, 0, 10);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2000) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.L21001, 0, 9999);
		validator.CollectionSize(x => x.L22002, 0, 9999);
		validator.CollectionSize(x => x.L23003, 0, 99999);
		validator.CollectionSize(x => x.L24004, 0, 99999);
		validator.CollectionSize(x => x.L25005, 0, 99999);
		validator.CollectionSize(x => x.L26006, 0, 99999);
		validator.CollectionSize(x => x.L27007, 0, 9999);
		validator.CollectionSize(x => x.L28008, 0, 999);
		foreach (var item in L21001) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L22002) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L23003) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L24004) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L25005) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L26006) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L27007) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L28008) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
