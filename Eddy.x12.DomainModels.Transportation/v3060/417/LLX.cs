using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._417;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(3)] public List<LLX_LL0> LL0 {get;set;} = new();
	[SectionPosition(4)] public List<PI_PriceAuthorityIdentification> PriceAuthorityIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 15);
		validator.CollectionSize(x => x.PriceAuthorityIdentification, 0, 30);
		validator.CollectionSize(x => x.LL0, 0, 25);
		foreach (var item in LL0) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
