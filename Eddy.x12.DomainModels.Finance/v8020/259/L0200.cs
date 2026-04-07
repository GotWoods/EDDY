using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._259;

public class L0200 {
	[SectionPosition(1)] public N9_ExtendedReferenceInformation ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public AMT_MonetaryAmountInformation MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(4)] public DFI_DefaultInformation DefaultInformation { get; set; } = new();
	[SectionPosition(5)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(7)] public PCT_PercentAmounts? PercentAmounts { get; set; }
	[SectionPosition(8)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(9)] public List<L0200_L0300> L0300 {get;set;} = new();
	[SectionPosition(10)] public List<L0200_L0400> L0400 {get;set;} = new();
	[SectionPosition(11)] public List<L0200_L0500> L0500 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.ExtendedReferenceInformation);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.Required(x => x.MonetaryAmountInformation);
		validator.Required(x => x.DefaultInformation);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.L0300, 1, 2147483647);
		validator.CollectionSize(x => x.L0400, 1, 2147483647);
		validator.CollectionSize(x => x.L0500, 1, 2147483647);
		foreach (var item in L0300) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0400) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0500) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
