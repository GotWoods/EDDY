using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Finance.v6010._130;

public class LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<HS_HealthScreening> HealthScreening { get; set; } = new();
	[SectionPosition(3)] public List<IMM_ImmunizationStatus> ImmunizationStatus { get; set; } = new();
	[SectionPosition(4)] public List<LLX_LHC> LHC {get;set;} = new();
	[SectionPosition(5)] public List<LLX_LSP> LSP {get;set;} = new();
	[SectionPosition(6)] public List<LLX_LSES> LSES {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.HealthScreening, 0, 10);
		validator.CollectionSize(x => x.ImmunizationStatus, 0, 1000);
		validator.CollectionSize(x => x.LHC, 0, 1000);
		validator.CollectionSize(x => x.LSP, 0, 30);
		validator.CollectionSize(x => x.LSES, 0, 1000);
		foreach (var item in LHC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSP) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSES) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
