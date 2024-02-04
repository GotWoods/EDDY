using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Transportation.v7040._355;

public class LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(3)] public List<LNM1_LDMG> LDMG {get;set;} = new();
	[SectionPosition(4)] public List<LNM1_LREF> LREF {get;set;} = new();
	[SectionPosition(5)] public List<LNM1_LN3> LN3 {get;set;} = new();
	[SectionPosition(6)] public List<LNM1_LN4> LN4 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		foreach (var item in LDMG) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN3) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
