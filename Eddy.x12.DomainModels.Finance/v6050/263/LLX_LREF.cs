using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Finance.v6050._263;

public class LLX_LREF {
	[SectionPosition(1)] public REF_ReferenceInformation ReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(3)] public MIR_MortgageInsuranceResponse MortgageInsuranceResponse { get; set; } = new();
	[SectionPosition(4)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(5)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public MIC_MortgageInsuranceCoverage? MortgageInsuranceCoverage { get; set; }
	[SectionPosition(7)] public List<LLX__LREF_LG63> LG63 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LREF>(this);
		validator.Required(x => x.ReferenceInformation);
		validator.Required(x => x.PartyIdentification);
		validator.Required(x => x.MortgageInsuranceResponse);
		validator.CollectionSize(x => x.TaxInformation, 0, 5);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.LG63, 1, 2147483647);
		foreach (var item in LG63) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
