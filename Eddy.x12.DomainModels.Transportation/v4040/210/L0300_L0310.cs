using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._210;

public class L0300_L0310 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(3)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(6)] public List<L0300__L0310_L0320> L0320 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300_L0310>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 5);
		validator.CollectionSize(x => x.L0320, 0, 10);
		foreach (var item in L0320) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
