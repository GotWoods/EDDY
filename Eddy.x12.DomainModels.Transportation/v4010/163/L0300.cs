using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._163;

public class L0300 {
	[SectionPosition(1)] public S5_StopOffDetails StopOffDetails { get; set; } = new();
	[SectionPosition(2)] public N1_Name? Name { get; set; }
	[SectionPosition(3)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(4)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(7)] public List<H6_SpecialServices> SpecialServices { get; set; } = new();
	[SectionPosition(8)] public List<G61_Contact> Contact { get; set; } = new();
	[SectionPosition(9)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(10)] public List<L0300_L0350> L0350 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300>(this);
		validator.Required(x => x.StopOffDetails);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 10);
		validator.CollectionSize(x => x.SpecialServices, 0, 5);
		validator.CollectionSize(x => x.Contact, 0, 5);
		validator.CollectionSize(x => x.DateTime, 0, 10);
		validator.CollectionSize(x => x.L0350, 0, 99999);
		foreach (var item in L0350) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
