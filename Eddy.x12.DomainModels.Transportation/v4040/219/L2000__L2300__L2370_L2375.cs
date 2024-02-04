using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._219;

public class L2000__L2300__L2370_L2375 {
	[SectionPosition(1)] public G61_Contact Contact { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(4)] public List<L2000__L2300__L2370__L2375_L2378> L2378 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2300__L2370_L2375>(this);
		validator.Required(x => x.Contact);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 5);
		validator.CollectionSize(x => x.HazardousCertification, 0, 6);
		validator.CollectionSize(x => x.L2378, 0, 25);
		foreach (var item in L2378) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
