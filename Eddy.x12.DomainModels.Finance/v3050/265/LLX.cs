using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._265;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(3)] public List<PDS_PropertyDescriptionLegalDescription> PropertyDescriptionLegalDescription { get; set; } = new();
	[SectionPosition(4)] public List<PDE_PropertyMetesAndBoundsDescription> PropertyMetesAndBoundsDescription { get; set; } = new();
	[SectionPosition(5)] public NX1_PropertyOrEntityIdentification? PropertyOrEntityIdentification { get; set; }
	[SectionPosition(6)] public List<NX2_RealEstatePropertyIDComponent> RealEstatePropertyIDComponent { get; set; } = new();
	[SectionPosition(7)] public PRD_MortgageLoanProductDescription? MortgageLoanProductDescription { get; set; }
	[SectionPosition(8)] public LRQ_MortgageCharacteristicsRequested? MortgageCharacteristicsRequested { get; set; }
	[SectionPosition(9)] public LN1_LoanSpecificData? LoanSpecificData { get; set; }
	[SectionPosition(10)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(11)] public List<LLX_LIN1> LIN1 {get;set;} = new();
	[SectionPosition(12)] public List<LLX_LMCD> LMCD {get;set;} = new();
	[SectionPosition(13)] public List<LLX_LN1> LN1 {get;set;} = new();
	[SectionPosition(14)] public List<LLX_LTIS> LTIS {get;set;} = new();
	[SectionPosition(15)] public List<LLX_LPWK> LPWK {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.ReferenceNumbers, 1, 12);
		validator.CollectionSize(x => x.PropertyDescriptionLegalDescription, 1, 20);
		validator.CollectionSize(x => x.PropertyMetesAndBoundsDescription, 1, 2147483647);
		validator.CollectionSize(x => x.RealEstatePropertyIDComponent, 0, 30);
		validator.CollectionSize(x => x.MessageText, 0, 100);
		validator.CollectionSize(x => x.LIN1, 1, 2147483647);
		validator.CollectionSize(x => x.LMCD, 1, 2147483647);
		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		validator.CollectionSize(x => x.LTIS, 1, 2147483647);
		validator.CollectionSize(x => x.LPWK, 0, 5);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LMCD) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTIS) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPWK) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
