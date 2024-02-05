using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v4040._242;

public class LHL {
	[SectionPosition(1)] public HL_HierarchicalLevel HierarchicalLevel { get; set; } = new();
	[SectionPosition(2)] public IIS_InterchangeIdentificationSegment? InterchangeIdentificationSegment { get; set; }
	[SectionPosition(3)] public N1_Name? Name { get; set; }
	[SectionPosition(4)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(5)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(6)] public List<LHL_LSTS> LSTS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL>(this);
		validator.Required(x => x.HierarchicalLevel);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 10);
		validator.CollectionSize(x => x.Quantity, 1, 2147483647);
		validator.CollectionSize(x => x.LSTS, 1, 2147483647);
		foreach (var item in LSTS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
