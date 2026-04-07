using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._813;

public class LTFS_LTIA {
	[SectionPosition(1)] public TIA_TaxInformationAndAmount TaxInformationAndAmount { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTFS_LTIA>(this);
		validator.Required(x => x.TaxInformationAndAmount);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.MessageText, 0, 1000);
		return validator.Results;
	}
}
