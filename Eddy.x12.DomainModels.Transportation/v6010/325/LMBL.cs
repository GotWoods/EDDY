using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Transportation.v6010._325;

public class LMBL {
	[SectionPosition(1)] public MBL_BillOfLading BillOfLading { get; set; } = new();
	[SectionPosition(2)] public L3_TotalWeightAndCharges? TotalWeightAndCharges { get; set; }
	[SectionPosition(3)] public C3_CurrencyIdentifier? CurrencyIdentifier { get; set; }
	[SectionPosition(4)] public List<R4_PortOrTerminal> PortOrTerminal { get; set; } = new();
	[SectionPosition(5)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<LMBL_LN1> LN1 {get;set;} = new();
	[SectionPosition(7)] public List<LMBL_LLIN> LLIN {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LMBL>(this);
		validator.Required(x => x.BillOfLading);
		validator.CollectionSize(x => x.PortOrTerminal, 0, 4);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.LN1, 0, 6);
		validator.CollectionSize(x => x.LLIN, 1, 999);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLIN) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
