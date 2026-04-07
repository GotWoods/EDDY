using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Finance.v6050._103;

public class LN1_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<BLN_BalanceInformation> BalanceInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<INT_Interest> Interest { get; set; } = new();
	[SectionPosition(5)] public PDS_PropertyDescriptionLegalDescription? PropertyDescriptionLegalDescription { get; set; }
	[SectionPosition(6)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public List<LN1__LLX_LSHI> LSHI {get;set;} = new();
	[SectionPosition(8)] public List<LN1__LLX_LNM1> LNM1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.BalanceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.Interest, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		foreach (var item in LSHI) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
