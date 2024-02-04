using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050._355;

public class LP4__LLX_LN1 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(3)] public List<LP4__LLX__LN1_LN3> LN3 {get;set;} = new();
	[SectionPosition(4)] public List<LP4__LLX__LN1_LN4> LN4 {get;set;} = new();
	[SectionPosition(5)] public List<LP4__LLX__LN1_LPER> LPER {get;set;} = new();
	[SectionPosition(6)] public List<LP4__LLX__LN1_LX1> LX1 {get;set;} = new();
	[SectionPosition(7)] public List<LP4__LLX__LN1_LDMG> LDMG {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.LN3, 0, 2);
		foreach (var item in LN3) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN4) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPER) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LDMG) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
