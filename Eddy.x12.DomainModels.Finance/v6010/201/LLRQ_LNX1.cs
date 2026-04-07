using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Finance.v6010._201;

public class LLRQ_LNX1 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(3)] public REA_RealEstatePropertyInformation? RealEstatePropertyInformation { get; set; }
	[SectionPosition(4)] public List<PDS_PropertyDescriptionLegalDescription> PropertyDescriptionLegalDescription { get; set; } = new();
	[SectionPosition(5)] public List<PDE_PropertyMetesAndBoundsDescription> PropertyMetesAndBoundsDescription { get; set; } = new();
	[SectionPosition(6)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(7)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLRQ_LNX1>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.LocationIDComponent, 1, 30);
		validator.CollectionSize(x => x.PropertyDescriptionLegalDescription, 0, 10);
		validator.CollectionSize(x => x.PropertyMetesAndBoundsDescription, 0, 50);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		return validator.Results;
	}
}
