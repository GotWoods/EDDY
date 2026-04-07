using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._176;

public class LCDS {
	[SectionPosition(1)] public CDS_CaseDescription CaseDescription { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public SPI_SpecificationIdentifier? SpecificationIdentifier { get; set; }
	[SectionPosition(4)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(5)] public List<CRC_ConditionsIndicator> ConditionsIndicator { get; set; } = new();
	[SectionPosition(6)] public List<PAM_PeriodAmount> PeriodAmount { get; set; } = new();
	[SectionPosition(7)] public BCU_LegalClaimUpdates? LegalClaimUpdates { get; set; }
	[SectionPosition(8)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(9)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(10)] public CED_CourtEventDescription? CourtEventDescription { get; set; }
	[SectionPosition(11)] public List<LCDS_LLM> LLM {get;set;} = new();
	[SectionPosition(12)] public List<LCDS_LAMT> LAMT {get;set;} = new();
	[SectionPosition(13)] public List<LCDS_LBBC> LBBC {get;set;} = new();
	[SectionPosition(14)] public List<LCDS_LNM1> LNM1 {get;set;} = new();
	[SectionPosition(15)] public List<LCDS_LEFI> LEFI {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCDS>(this);
		validator.Required(x => x.CaseDescription);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.ConditionsIndicator, 1, 2147483647);
		validator.CollectionSize(x => x.PeriodAmount, 1, 2147483647);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.Quantity, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		validator.CollectionSize(x => x.LAMT, 1, 2147483647);
		validator.CollectionSize(x => x.LBBC, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		validator.CollectionSize(x => x.LEFI, 1, 2147483647);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LBBC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LEFI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
