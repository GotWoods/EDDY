using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._823;

public class LDEP__LBAT__LBPR__LLX__LNM1_LPEN {
	[SectionPosition(1)] public PEN_PensionInformation PensionInformation { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<LDEP__LBAT__LBPR__LLX__LNM1__LPEN_LINV> LINV {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDEP__LBAT__LBPR__LLX__LNM1_LPEN>(this);
		validator.Required(x => x.PensionInformation);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.LINV, 1, 2147483647);
		foreach (var item in LINV) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
