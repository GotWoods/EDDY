using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._228;

public class LW2 {
	[SectionPosition(1)] public W2_EquipmentIdentification EquipmentIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NA_CrossReferenceEquipment> CrossReferenceEquipment { get; set; } = new();
	[SectionPosition(3)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(5)] public List<LW2_LN1> LN1 {get;set;} = new();
	[SectionPosition(6)] public List<LW2_LEQD> LEQD {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LW2>(this);
		validator.Required(x => x.EquipmentIdentification);
		validator.CollectionSize(x => x.CrossReferenceEquipment, 0, 30);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.LN1, 0, 10);
		validator.CollectionSize(x => x.LEQD, 1, 1000);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LEQD) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
