using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Finance.v6050._259;

public class L0200_L0500 {
	[SectionPosition(1)] public FIS_MortgageLoanFiscalData MortgageLoanFiscalData { get; set; } = new();
	[SectionPosition(2)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(3)] public List<L0200__L0500_L0510> L0510 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0500>(this);
		validator.Required(x => x.MortgageLoanFiscalData);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		validator.CollectionSize(x => x.L0510, 1, 2147483647);
		foreach (var item in L0510) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
