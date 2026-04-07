using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Finance.v5020._176;

public class LFGS {
	[SectionPosition(1)] public FGS_FormGroup FormGroup { get; set; } = new();
	[SectionPosition(2)] public CDS_CaseDescription? CaseDescription { get; set; }
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public SPI_SpecificationIdentifier? SpecificationIdentifier { get; set; }
	[SectionPosition(5)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<CRC_ConditionsIndicator> ConditionsIndicator { get; set; } = new();
	[SectionPosition(7)] public List<PAM_PeriodAmount> PeriodAmount { get; set; } = new();
	[SectionPosition(8)] public BCU_LegalClaimUpdates? LegalClaimUpdates { get; set; }
	[SectionPosition(9)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(10)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(11)] public CED_AdministrationOfJusticeEventDescription? AdministrationOfJusticeEventDescription { get; set; }
	[SectionPosition(12)] public List<LFGS_LLM> LLM {get;set;} = new();
	[SectionPosition(13)] public List<LFGS_LAMT> LAMT {get;set;} = new();
	[SectionPosition(14)] public List<LFGS_LBBC> LBBC {get;set;} = new();
	[SectionPosition(15)] public List<LFGS_LNM1> LNM1 {get;set;} = new();
	[SectionPosition(16)] public List<LFGS_LEFI> LEFI {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LFGS>(this);
		validator.Required(x => x.FormGroup);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ConditionsIndicator, 1, 2147483647);
		validator.CollectionSize(x => x.PeriodAmount, 1, 2147483647);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
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
