using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._204;

public class LS5_LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(3)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(6)] public List<G61_Contact> Contact { get; set; } = new();
	[SectionPosition(7)] public List<LS5__LN1_LN7> LN7 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LS5_LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 5);
		validator.CollectionSize(x => x.Contact, 0, 3);
		validator.CollectionSize(x => x.LN7, 0, 10);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
