using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Transportation.v3030._218;

namespace Eddy.x12.DomainModels.Transportation.v3030;

public class Edi218_MotorCarrierTariffInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public TF_TariffInformation TariffInformation { get; set; } = new();
	[SectionPosition(3)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(4)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(5)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(6)] public List<L2000> L2000 {get;set;} = new();

	//Details
	[SectionPosition(7)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(8)] public List<L2100> L2100 {get;set;} = new();
	[SectionPosition(9)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(10)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(11)] public List<L2200> L2200 {get;set;} = new();
	[SectionPosition(12)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(13)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(14)] public List<L2300> L2300 {get;set;} = new();
	[SectionPosition(15)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(16)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(17)] public List<L2400> L2400 {get;set;} = new();
	[SectionPosition(18)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(19)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(20)] public List<L2500> L2500 {get;set;} = new();
	[SectionPosition(21)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(22)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(23)] public List<L2600> L2600 {get;set;} = new();
	[SectionPosition(24)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(25)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(26)] public List<L2700> L2700 {get;set;} = new();
	[SectionPosition(27)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(28)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(29)] public List<L2800> L2800 {get;set;} = new();
	[SectionPosition(30)] public LE_LoopTrailer? LoopTrailer { get; set; }

	//Summary
	[SectionPosition(31)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi218_MotorCarrierTariffInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TariffInformation);
		validator.CollectionSize(x => x.DateTime, 0, 5);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 10);
		

		validator.CollectionSize(x => x.L0100, 0, 10);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2000) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.L2100, 0, 9999);
		validator.CollectionSize(x => x.L2200, 0, 9999);
		validator.CollectionSize(x => x.L2300, 0, 99999);
		validator.CollectionSize(x => x.L2400, 0, 99999);
		validator.CollectionSize(x => x.L2500, 0, 99999);
		validator.CollectionSize(x => x.L2600, 0, 99999);
		validator.CollectionSize(x => x.L2700, 0, 9999);
		validator.CollectionSize(x => x.L2800, 0, 999);
		foreach (var item in L2100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2200) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2300) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2400) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2500) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2600) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2700) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2800) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
