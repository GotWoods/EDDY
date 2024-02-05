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
	[SectionPosition(7)] public LS_LoopHeader? LoopHeader1 { get; set; }
	[SectionPosition(8)] public List<LSCL> LSCL1 {get;set;} = new();
	[SectionPosition(9)] public LE_LoopTrailer? LoopTrailer1 { get; set; }
	[SectionPosition(10)] public LS_LoopHeader? LoopHeader2 { get; set; }
	[SectionPosition(11)] public List<LSCL> LSCL2 {get;set;} = new();
	[SectionPosition(12)] public LE_LoopTrailer? LoopTrailer2 { get; set; }
	[SectionPosition(13)] public LS_LoopHeader? LoopHeader3 { get; set; }
	[SectionPosition(14)] public List<LLX> LLX3 {get;set;} = new();
	[SectionPosition(15)] public LE_LoopTrailer? LoopTrailer3 { get; set; }
	[SectionPosition(16)] public LS_LoopHeader? LoopHeader4 { get; set; }
	[SectionPosition(17)] public List<LLX> LLX4 {get;set;} = new();
	[SectionPosition(18)] public LE_LoopTrailer? LoopTrailer4 { get; set; }
	[SectionPosition(19)] public LS_LoopHeader? LoopHeader5 { get; set; }
	[SectionPosition(20)] public List<LLX> LLX5 {get;set;} = new();
	[SectionPosition(21)] public LE_LoopTrailer? LoopTrailer5 { get; set; }
	[SectionPosition(22)] public LS_LoopHeader? LoopHeader6 { get; set; }
	[SectionPosition(23)] public List<LLX> LLX6 {get;set;} = new();
	[SectionPosition(24)] public LE_LoopTrailer? LoopTrailer6 { get; set; }
	[SectionPosition(25)] public LS_LoopHeader? LoopHeader7 { get; set; }
	[SectionPosition(26)] public List<LSCL> LSCL7 {get;set;} = new();
	[SectionPosition(27)] public LE_LoopTrailer? LoopTrailer7 { get; set; }
	[SectionPosition(28)] public LS_LoopHeader? LoopHeader8 { get; set; }
	[SectionPosition(29)] public List<LLX> LLX8 {get;set;} = new();
	[SectionPosition(30)] public LE_LoopTrailer? LoopTrailer8 { get; set; }

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
		

		validator.CollectionSize(x => x.LSCL1, 0, 9999);
		validator.CollectionSize(x => x.LSCL2, 0, 9999);
		validator.CollectionSize(x => x.LLX3, 0, 99999);
		validator.CollectionSize(x => x.LLX4, 0, 99999);
		validator.CollectionSize(x => x.LLX5, 0, 99999);
		validator.CollectionSize(x => x.LLX6, 0, 99999);
		validator.CollectionSize(x => x.LSCL7, 0, 9999);
		validator.CollectionSize(x => x.LLX8, 0, 999);
		foreach (var item in LSCL1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSCL2) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX3) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX4) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX5) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX6) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSCL7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX8) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
