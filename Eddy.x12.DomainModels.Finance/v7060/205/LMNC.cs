using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Finance.v7060._205;

public class LMNC {
	[SectionPosition(1)] public MNC_MortgageNoteCharacteristics MortgageNoteCharacteristics { get; set; } = new();
	[SectionPosition(2)] public SOM_StatusOfMortgage? StatusOfMortgage { get; set; }
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public List<INT_Interest> Interest { get; set; } = new();
	[SectionPosition(7)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(8)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(9)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(10)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(11)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(12)] public List<LMNC_LCDI> LCDI {get;set;} = new();
	[SectionPosition(13)] public List<LMNC_LIN1> LIN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LMNC>(this);
		validator.Required(x => x.MortgageNoteCharacteristics);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 20);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.Interest, 0, 2);
		validator.CollectionSize(x => x.PercentAmounts, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 10);
		validator.CollectionSize(x => x.QuantityInformation, 0, 6);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 12);
		validator.CollectionSize(x => x.Information, 0, 12);
		validator.CollectionSize(x => x.LCDI, 1, 2147483647);
		validator.CollectionSize(x => x.LIN1, 1, 2147483647);
		foreach (var item in LCDI) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
