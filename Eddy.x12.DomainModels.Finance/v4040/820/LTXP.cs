using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._820;

public class LTXP {
	[SectionPosition(1)] public TXP_TaxPayment TaxPayment { get; set; } = new();
	[SectionPosition(2)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTXP>(this);
		validator.Required(x => x.TaxPayment);
		validator.CollectionSize(x => x.TaxInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		return validator.Results;
	}
}
