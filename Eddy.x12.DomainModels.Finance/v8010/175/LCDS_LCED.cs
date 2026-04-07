using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._175;

public class LCDS_LCED {
	[SectionPosition(1)] public CED_AdministrationOfJusticeEventDescription AdministrationOfJusticeEventDescription { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public SPI_SpecificationIdentifier? SpecificationIdentifier { get; set; }
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(6)] public List<PAM_PeriodAmount> PeriodAmount { get; set; } = new();
	[SectionPosition(7)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(8)] public List<CRC_ConditionsIndicator> ConditionsIndicator { get; set; } = new();
	[SectionPosition(9)] public List<CDS_CaseDescription> CaseDescription { get; set; } = new();
	[SectionPosition(10)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(11)] public List<LCDS__LCED_LLM> LLM {get;set;} = new();
	[SectionPosition(12)] public List<LCDS__LCED_LNM1> LNM1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCDS_LCED>(this);
		validator.Required(x => x.AdministrationOfJusticeEventDescription);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.PeriodAmount, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ConditionsIndicator, 1, 2147483647);
		validator.CollectionSize(x => x.CaseDescription, 1, 2147483647);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
