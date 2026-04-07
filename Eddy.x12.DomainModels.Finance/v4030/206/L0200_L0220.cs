using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._206;

public class L0200_L0220 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(3)] public List<PDS_PropertyDescriptionLegalDescription> PropertyDescriptionLegalDescription { get; set; } = new();
	[SectionPosition(4)] public List<PDE_PropertyMetesAndBoundsDescription> PropertyMetesAndBoundsDescription { get; set; } = new();
	[SectionPosition(5)] public REA_RealEstatePropertyInformation? RealEstatePropertyInformation { get; set; }
	[SectionPosition(6)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(7)] public List<REC_RealEstateCondition> RealEstateCondition { get; set; } = new();
	[SectionPosition(8)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(9)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(10)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(11)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(12)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(13)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(14)] public CTP_PricingInformation? PricingInformation { get; set; }
	[SectionPosition(15)] public List<L0200__L0220_L0221> L0221 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0220>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.LocationIDComponent, 1, 2147483647);
		validator.CollectionSize(x => x.PropertyDescriptionLegalDescription, 1, 2147483647);
		validator.CollectionSize(x => x.PropertyMetesAndBoundsDescription, 1, 2147483647);
		validator.CollectionSize(x => x.Information, 0, 5);
		validator.CollectionSize(x => x.RealEstateCondition, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 2);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 20);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.Paperwork, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 2);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 20);
		validator.CollectionSize(x => x.L0221, 1, 2147483647);
		foreach (var item in L0221) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
