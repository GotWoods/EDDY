using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._263;

public class LLX_LREF {
	[SectionPosition(1)] public REF_ReferenceNumbers ReferenceNumbers { get; set; } = new();
	[SectionPosition(2)] public N1_Name Name { get; set; } = new();
	[SectionPosition(3)] public MIR_MortgageInsuranceResponse MortgageInsuranceResponse { get; set; } = new();
	[SectionPosition(4)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(5)] public List<LLX__LREF_LG63> LG63 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LREF>(this);
		validator.Required(x => x.ReferenceNumbers);
		validator.Required(x => x.Name);
		validator.Required(x => x.MortgageInsuranceResponse);
		validator.CollectionSize(x => x.TaxInformation, 0, 5);
		validator.CollectionSize(x => x.LG63, 1, 2147483647);
		foreach (var item in LG63) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
