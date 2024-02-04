using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Transportation.v6040._424;

public class LN1_LC1 {
	[SectionPosition(1)] public CI_CarrierInterchangeAgreement CarrierInterchangeAgreement { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(3)] public AMT_MonetaryAmountInformation? MonetaryAmountInformation { get; set; }
	[SectionPosition(4)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(5)] public List<LN1__LC1_LSWC> LSWC {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1_LC1>(this);
		validator.Required(x => x.CarrierInterchangeAgreement);
		validator.CollectionSize(x => x.Measurements, 0, 2);
		validator.CollectionSize(x => x.LSWC, 0, 999);
		foreach (var item in LSWC) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
