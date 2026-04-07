using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._261;

public class LLX_LNX1 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_RealEstatePropertyIDComponent> RealEstatePropertyIDComponent { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(5)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(6)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(7)] public List<PDS_PropertyDescriptionLegalDescription> PropertyDescriptionLegalDescription { get; set; } = new();
	[SectionPosition(8)] public List<PDE_PropertyMetesAndBoundsDescription> PropertyMetesAndBoundsDescription { get; set; } = new();
	[SectionPosition(9)] public List<PEX_PropertyOrHousingExpense> PropertyOrHousingExpense { get; set; } = new();
	[SectionPosition(10)] public REC_RealEstateCondition? RealEstateCondition { get; set; }
	[SectionPosition(11)] public REA_RealEstatePropertyInformation? RealEstatePropertyInformation { get; set; }
	[SectionPosition(12)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(13)] public List<AM1_InformationalValues> InformationalValues { get; set; } = new();
	[SectionPosition(14)] public List<API_ActivityOrProcessInformation> ActivityOrProcessInformation { get; set; } = new();
	[SectionPosition(15)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(16)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(17)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(18)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(19)] public List<LLX__LNX1_LIN1> LIN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LNX1>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.RealEstatePropertyIDComponent, 1, 7);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 7);
		validator.CollectionSize(x => x.Paperwork, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 16);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 5);
		validator.CollectionSize(x => x.PropertyDescriptionLegalDescription, 1, 2147483647);
		validator.CollectionSize(x => x.PropertyMetesAndBoundsDescription, 1, 2147483647);
		validator.CollectionSize(x => x.PropertyOrHousingExpense, 0, 5);
		validator.CollectionSize(x => x.Information, 0, 30);
		validator.CollectionSize(x => x.InformationalValues, 1, 2147483647);
		validator.CollectionSize(x => x.ActivityOrProcessInformation, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 10);
		validator.CollectionSize(x => x.Quantity, 0, 2);
		validator.CollectionSize(x => x.PercentAmounts, 0, 4);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.LIN1, 0, 4);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
