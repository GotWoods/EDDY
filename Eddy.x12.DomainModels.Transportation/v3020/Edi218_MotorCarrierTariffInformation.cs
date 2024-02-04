using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;
using Eddy.x12.DomainModels.Transportation.v3020._218;

namespace Eddy.x12.DomainModels.Transportation.v3020;

public class Edi218_MotorCarrierTariffInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public TF_TariffInformation TariffInformation { get; set; } = new();
	[SectionPosition(3)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(4)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(5)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(6)] public List<LTS> LTS {get;set;} = new();

	//Details
	[SectionPosition(7)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(8)] public List<LSCL> LSCL {get;set;} = new();
	[SectionPosition(9)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(10)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(11)] public List<LSCL> LSCL {get;set;} = new();
	[SectionPosition(12)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(13)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(14)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(15)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(16)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(17)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(18)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(19)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(20)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(21)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(22)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(23)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(24)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(25)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(26)] public List<LSCL> LSCL {get;set;} = new();
	[SectionPosition(27)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(28)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(29)] public List<LLX> LLX {get;set;} = new();
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
		

		validator.CollectionSize(x => x.LN1, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTS) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LSCL, 0, 9999);
		validator.CollectionSize(x => x.LSCL, 0, 9999);
		validator.CollectionSize(x => x.LLX, 0, 99999);
		validator.CollectionSize(x => x.LLX, 0, 99999);
		validator.CollectionSize(x => x.LLX, 0, 99999);
		validator.CollectionSize(x => x.LLX, 0, 99999);
		validator.CollectionSize(x => x.LSCL, 0, 9999);
		validator.CollectionSize(x => x.LLX, 0, 999);
		foreach (var item in LSCL) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSCL) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSCL) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
