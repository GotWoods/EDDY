using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Finance.v7060._820;

public class L5000__L5100_L5120 {
	[SectionPosition(1)] public PEN_PensionInformation PensionInformation { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<L5000__L5100__L5120_L5121> L5121 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L5000__L5100_L5120>(this);
		validator.Required(x => x.PensionInformation);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.L5121, 1, 2147483647);
		foreach (var item in L5121) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
