using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Transportation.v7030._219;

public class L2000__L2300_L2350 {
	[SectionPosition(1)] public G61_Contact Contact { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(4)] public List<L2000__L2300__L2350_L2355> L2355 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2300_L2350>(this);
		validator.Required(x => x.Contact);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 5);
		validator.CollectionSize(x => x.HazardousCertification, 0, 6);
		validator.CollectionSize(x => x.L2355, 0, 25);
		foreach (var item in L2355) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
