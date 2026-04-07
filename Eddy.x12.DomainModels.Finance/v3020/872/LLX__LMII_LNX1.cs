using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Finance.v3020._872;

public class LLX__LMII_LNX1 {
	[SectionPosition(1)] public NX1_RealEstatePropertyIdentification RealEstatePropertyIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_RealEstatePropertyIDComponent> RealEstatePropertyIDComponent { get; set; } = new();
	[SectionPosition(3)] public List<LLX__LMII__LNX1_LPAS> LPAS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LMII_LNX1>(this);
		validator.Required(x => x.RealEstatePropertyIdentification);
		validator.CollectionSize(x => x.RealEstatePropertyIDComponent, 1, 30);
		validator.CollectionSize(x => x.LPAS, 1, 5);
		foreach (var item in LPAS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
