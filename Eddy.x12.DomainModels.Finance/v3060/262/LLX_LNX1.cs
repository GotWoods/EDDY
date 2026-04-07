using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._262;

public class LLX_LNX1 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_RealEstatePropertyIDComponent> RealEstatePropertyIDComponent { get; set; } = new();
	[SectionPosition(3)] public List<PEX_PropertyOrHousingExpense> PropertyOrHousingExpense { get; set; } = new();
	[SectionPosition(4)] public List<PDS_PropertyDescriptionLegalDescription> PropertyDescriptionLegalDescription { get; set; } = new();
	[SectionPosition(5)] public List<PDE_PropertyMetesAndBoundsDescription> PropertyMetesAndBoundsDescription { get; set; } = new();
	[SectionPosition(6)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(7)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(8)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(9)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(10)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(11)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(12)] public List<LLX__LNX1_LIII> LIII {get;set;} = new();
	[SectionPosition(13)] public List<LLX__LNX1_LLQ> LLQ {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LNX1>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.RealEstatePropertyIDComponent, 1, 7);
		validator.CollectionSize(x => x.PropertyOrHousingExpense, 0, 3);
		validator.CollectionSize(x => x.PropertyDescriptionLegalDescription, 1, 2147483647);
		validator.CollectionSize(x => x.PropertyMetesAndBoundsDescription, 1, 2147483647);
		validator.CollectionSize(x => x.Quantity, 0, 25);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 16);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 6);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 43);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 10);
		validator.CollectionSize(x => x.PercentAmounts, 0, 8);
		validator.CollectionSize(x => x.LIII, 1, 2147483647);
		validator.CollectionSize(x => x.LLQ, 1, 2147483647);
		foreach (var item in LIII) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLQ) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
