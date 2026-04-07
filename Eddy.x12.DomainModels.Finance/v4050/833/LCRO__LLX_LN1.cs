using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._833;

public class LCRO__LLX_LN1 {
	[SectionPosition(1)] public N1_Name PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_AddressInformation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<REF_ReferenceIdentification> ReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(7)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(8)] public List<LCRO__LLX__LN1_LEMP> LEMP {get;set;} = new();
	[SectionPosition(9)] public List<LCRO__LLX__LN1_LFAA> LFAA {get;set;} = new();
	[SectionPosition(10)] public List<LCRO__LLX__LN1_LCDA> LCDA {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCRO__LLX_LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 12);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 3);
		validator.CollectionSize(x => x.LEMP, 0, 20);
		validator.CollectionSize(x => x.LFAA, 0, 100);
		validator.CollectionSize(x => x.LCDA, 0, 100);
		foreach (var item in LEMP) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFAA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LCDA) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
