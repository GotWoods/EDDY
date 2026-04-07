using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Finance.v5030._201;

public class LLRQ_LIN1 {
	[SectionPosition(1)] public IN1_IndividualIdentification IndividualIdentification { get; set; } = new();
	[SectionPosition(2)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(3)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(4)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(5)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(7)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(8)] public N10_QuantityAndDescription? QuantityAndDescription { get; set; }
	[SectionPosition(9)] public MSG_MessageText? MessageText { get; set; }
	[SectionPosition(10)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(11)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(12)] public FTH_FirstTimeHomeBuyer? FirstTimeHomeBuyer { get; set; }
	[SectionPosition(13)] public List<PPY_PersonalPropertyDescription> PersonalPropertyDescription { get; set; } = new();
	[SectionPosition(14)] public List<LLRQ__LIN1_LAIN> LAIN {get;set;} = new();
	[SectionPosition(15)] public List<LLRQ__LIN1_LPEX> LPEX {get;set;} = new();
	[SectionPosition(16)] public List<LLRQ__LIN1_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(17)] public List<LLRQ__LIN1_LN1> LN1 {get;set;} = new();
	[SectionPosition(18)] public List<LLRQ__LIN1_LREA> LREA {get;set;} = new();
	[SectionPosition(19)] public List<LLRQ__LIN1_LNM1> LNM1 {get;set;} = new();
	[SectionPosition(20)] public List<LLRQ__LIN1_LCDA> LCDA {get;set;} = new();
	[SectionPosition(21)] public List<LLRQ__LIN1_LFAA> LFAA {get;set;} = new();
	[SectionPosition(22)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(23)] public List<LLRQ__LIN1_LAMT> LAMT {get;set;} = new();
	[SectionPosition(24)] public LE_LoopTrailer? LoopTrailer { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLRQ_LIN1>(this);
		validator.Required(x => x.IndividualIdentification);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 1, 10);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 19);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 3);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.PersonalPropertyDescription, 0, 20);
		validator.CollectionSize(x => x.LAIN, 1, 2147483647);
		validator.CollectionSize(x => x.LPEX, 0, 20);
		validator.CollectionSize(x => x.LNX1, 0, 10);
		validator.CollectionSize(x => x.LN1, 0, 20);
		validator.CollectionSize(x => x.LREA, 0, 20);
		validator.CollectionSize(x => x.LNM1, 0, 20);
		validator.CollectionSize(x => x.LCDA, 0, 100);
		validator.CollectionSize(x => x.LFAA, 0, 100);
		validator.CollectionSize(x => x.LAMT, 0, 10);
		foreach (var item in LAIN) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPEX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LREA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LCDA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFAA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
