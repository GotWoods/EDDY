using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._155;

public class L20000 {
	[SectionPosition(1)] public HL_HierarchicalLevel HierarchicalLevel { get; set; } = new();
	[SectionPosition(2)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public LUI_LanguageUse? LanguageUse { get; set; }
	[SectionPosition(5)] public C3_CurrencyIdentifier? CurrencyIdentifier { get; set; }
	[SectionPosition(6)] public List<CRC_ConditionsIndicator> ConditionsIndicator { get; set; } = new();
	[SectionPosition(7)] public List<MTX_Text> Text { get; set; } = new();
	[SectionPosition(8)] public List<L20000_L21000> L21000 {get;set;} = new();
	[SectionPosition(9)] public List<L20000_L22000> L22000 {get;set;} = new();
	[SectionPosition(10)] public List<L20000_L23000> L23000 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000>(this);
		validator.Required(x => x.HierarchicalLevel);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.ConditionsIndicator, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		validator.CollectionSize(x => x.L21000, 1, 2147483647);
		validator.CollectionSize(x => x.L22000, 1, 2147483647);
		validator.CollectionSize(x => x.L23000, 1, 2147483647);
		foreach (var item in L21000) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L22000) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L23000) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
