using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Transportation.v5020._219;

public class L2000_L2200 {
	[SectionPosition(1)] public G61_Contact Contact { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(4)] public List<L2000__L2200_L2250> L2250 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000_L2200>(this);
		validator.Required(x => x.Contact);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.HazardousCertification, 0, 10);
		validator.CollectionSize(x => x.L2250, 0, 25);
		foreach (var item in L2250) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
