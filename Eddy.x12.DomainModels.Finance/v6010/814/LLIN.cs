using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Finance.v6010._814;

public class LLIN {
	[SectionPosition(1)] public LIN_ItemIdentification ItemIdentification { get; set; } = new();
	[SectionPosition(2)] public ASI_ActionOrStatusIndicator? ActionOrStatusIndicator { get; set; }
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(6)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(7)] public PM_ElectronicFundsTransferInformation? ElectronicFundsTransferInformation { get; set; }
	[SectionPosition(8)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(9)] public List<MTX_Text> Text { get; set; } = new();
	[SectionPosition(10)] public List<LLIN_LFA1> LFA1 {get;set;} = new();
	[SectionPosition(11)] public List<LLIN_LNM1> LNM1 {get;set;} = new();
	[SectionPosition(12)] public List<LLIN_LLM> LLM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLIN>(this);
		validator.Required(x => x.ItemIdentification);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		validator.CollectionSize(x => x.LFA1, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		foreach (var item in LFA1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
