using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Transportation.v7060._204;

public class L0300__L0350__L0360_L0365 {
	[SectionPosition(1)] public G61_Contact Contact { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(4)] public List<L0300__L0350__L0360__L0365_L0370> L0370 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300__L0350__L0360_L0365>(this);
		validator.Required(x => x.Contact);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 5);
		validator.CollectionSize(x => x.HazardousCertification, 0, 6);
		validator.CollectionSize(x => x.L0370, 0, 25);
		foreach (var item in L0370) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
