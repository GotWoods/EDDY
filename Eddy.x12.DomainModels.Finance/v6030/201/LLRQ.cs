using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._201;

public class LLRQ {
	[SectionPosition(1)] public LRQ_MortgageCharacteristicsRequested MortgageCharacteristicsRequested { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(4)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(5)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(6)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(7)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(8)] public List<RES_RealEstateSalesPriceChange> RealEstateSalesPriceChange { get; set; } = new();
	[SectionPosition(9)] public MCD_MortgageClosingData? MortgageClosingData { get; set; }
	[SectionPosition(10)] public SOM_StatusOfMortgage? StatusOfMortgage { get; set; }
	[SectionPosition(11)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(12)] public List<LIN_ItemIdentification> ItemIdentification { get; set; } = new();
	[SectionPosition(13)] public BEP_BorrowerEducationProgram? BorrowerEducationProgram { get; set; }
	[SectionPosition(14)] public List<LLRQ_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(15)] public List<LLRQ_LPEX> LPEX {get;set;} = new();
	[SectionPosition(16)] public List<LLRQ_LAMT> LAMT {get;set;} = new();
	[SectionPosition(17)] public List<LLRQ_LIN1> LIN1 {get;set;} = new();
	[SectionPosition(18)] public List<LLRQ_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLRQ>(this);
		validator.Required(x => x.MortgageCharacteristicsRequested);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		validator.CollectionSize(x => x.RealEstateSalesPriceChange, 1, 2147483647);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.ItemIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.LNX1, 0, 10);
		validator.CollectionSize(x => x.LPEX, 1, 20);
		validator.CollectionSize(x => x.LAMT, 1, 2147483647);
		validator.CollectionSize(x => x.LIN1, 1, 15);
		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPEX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
