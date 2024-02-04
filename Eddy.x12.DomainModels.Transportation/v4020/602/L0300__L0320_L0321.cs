using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._602;

public class L0300__L0320_L0321 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public SRD_ScaleRateDetail? ScaleRateDetail { get; set; }
	[SectionPosition(3)] public List<L0300__L0320__L0321_L0322> L0322 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300__L0320_L0321>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.L0322, 0, 100);
		foreach (var item in L0322) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
