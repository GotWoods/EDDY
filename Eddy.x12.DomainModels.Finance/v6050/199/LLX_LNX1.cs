using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Finance.v6050._199;

public class LLX_LNX1 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(3)] public List<PDS_PropertyDescriptionLegalDescription> PropertyDescriptionLegalDescription { get; set; } = new();
	[SectionPosition(4)] public List<PDE_PropertyMetesAndBoundsDescription> PropertyMetesAndBoundsDescription { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LNX1>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.LocationIDComponent, 0, 30);
		validator.CollectionSize(x => x.PropertyDescriptionLegalDescription, 0, 20);
		validator.CollectionSize(x => x.PropertyMetesAndBoundsDescription, 1, 2147483647);
		return validator.Results;
	}
}
