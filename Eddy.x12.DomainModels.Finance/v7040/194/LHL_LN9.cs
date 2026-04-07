using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Finance.v7040._194;

public class LHL_LN9 {
	[SectionPosition(1)] public N9_ExtendedReferenceInformation ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<MTX_Text> Text { get; set; } = new();
	[SectionPosition(4)] public List<LHL__LN9_LINX> LINX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LN9>(this);
		validator.Required(x => x.ExtendedReferenceInformation);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		validator.CollectionSize(x => x.LINX, 1, 2147483647);
		foreach (var item in LINX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
