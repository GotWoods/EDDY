using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Transportation.v6030._358;

public class LP4_LVID {
	[SectionPosition(1)] public VID_ConveyanceIdentification ConveyanceIdentification { get; set; } = new();
	[SectionPosition(2)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(3)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<LP4__LVID_LMBL> LMBL {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LVID>(this);
		validator.Required(x => x.ConveyanceIdentification);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 30);
		validator.CollectionSize(x => x.LMBL, 0, 9999);
		foreach (var item in LMBL) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
