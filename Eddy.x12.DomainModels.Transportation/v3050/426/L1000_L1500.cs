using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._426;

public class L1000_L1500 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(3)] public List<L1000__L1500_L1510> L1510 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L1000_L1500>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 15);
		validator.CollectionSize(x => x.L1510, 0, 25);
		foreach (var item in L1510) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
