using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Transportation.v3040._204;

public class L0400_L0410 {
	[SectionPosition(1)] public G61_Contact Contact { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(4)] public List<L0400__L0410_L0411> L0411 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400_L0410>(this);
		validator.Required(x => x.Contact);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 5);
		validator.CollectionSize(x => x.HazardousCertification, 0, 6);
		validator.CollectionSize(x => x.L0411, 0, 25);
		foreach (var item in L0411) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
