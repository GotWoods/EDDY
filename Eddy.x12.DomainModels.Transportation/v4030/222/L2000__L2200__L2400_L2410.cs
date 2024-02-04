using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Transportation.v4030._222;

public class L2000__L2200__L2400_L2410 {
	[SectionPosition(1)] public G61_Contact Contact { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(4)] public List<L2000__L2200__L2400__L2410_L2415> L2415 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2200__L2400_L2410>(this);
		validator.Required(x => x.Contact);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 5);
		validator.CollectionSize(x => x.HazardousCertification, 0, 6);
		validator.CollectionSize(x => x.L2415, 1, 25);
		foreach (var item in L2415) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
