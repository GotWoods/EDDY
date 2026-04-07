using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Finance.v5020._155;

public class L20000__L23000__L23500__L23540_L23541 {
	[SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; } = new();
	[SectionPosition(2)] public List<LQ_IndustryCodeIdentification> IndustryCodeIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000__L23000__L23500__L23540_L23541>(this);
		validator.Required(x => x.CodeSourceInformation);
		validator.CollectionSize(x => x.IndustryCodeIdentification, 1, 2147483647);
		return validator.Results;
	}
}
