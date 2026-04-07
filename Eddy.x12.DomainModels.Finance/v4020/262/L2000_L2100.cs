using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._262;

public class L2000_L2100 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(3)] public List<PDS_PropertyDescriptionLegalDescription> PropertyDescriptionLegalDescription { get; set; } = new();
	[SectionPosition(4)] public List<PDE_PropertyMetesAndBoundsDescription> PropertyMetesAndBoundsDescription { get; set; } = new();
	[SectionPosition(5)] public REA_RealEstatePropertyInformation? RealEstatePropertyInformation { get; set; }
	[SectionPosition(6)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(7)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(8)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(9)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(10)] public List<CRC_ConditionsIndicator> ConditionsIndicator { get; set; } = new();
	[SectionPosition(11)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(12)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(13)] public REC_RealEstateCondition? RealEstateCondition { get; set; }
	[SectionPosition(14)] public List<L2000__L2100_L2110> L2110 {get;set;} = new();
	[SectionPosition(15)] public List<L2000__L2100_L2120> L2120 {get;set;} = new();
	[SectionPosition(16)] public List<L2000__L2100_L2130> L2130 {get;set;} = new();
	[SectionPosition(17)] public List<L2000__L2100_L2140> L2140 {get;set;} = new();
	[SectionPosition(18)] public List<L2000__L2100_L2150> L2150 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000_L2100>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.LocationIDComponent, 1, 2147483647);
		validator.CollectionSize(x => x.PropertyDescriptionLegalDescription, 1, 2147483647);
		validator.CollectionSize(x => x.PropertyMetesAndBoundsDescription, 1, 2147483647);
		validator.CollectionSize(x => x.Quantity, 0, 25);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 30);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 6);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 43);
		validator.CollectionSize(x => x.ConditionsIndicator, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 10);
		validator.CollectionSize(x => x.PercentAmounts, 0, 8);
		validator.CollectionSize(x => x.L2110, 1, 2147483647);
		validator.CollectionSize(x => x.L2120, 1, 2147483647);
		validator.CollectionSize(x => x.L2130, 1, 2147483647);
		validator.CollectionSize(x => x.L2140, 1, 2147483647);
		validator.CollectionSize(x => x.L2150, 1, 2147483647);
		foreach (var item in L2110) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2120) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2130) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2140) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2150) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
