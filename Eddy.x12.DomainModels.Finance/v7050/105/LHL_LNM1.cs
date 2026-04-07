using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Finance.v7050._105;

public class LHL_LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<NX1_PropertyOrEntityIdentification> PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(3)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(4)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(5)] public List<N4_GeographicLocation> GeographicLocation { get; set; } = new();
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(7)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(8)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(9)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(10)] public List<LUI_LanguageUse> LanguageUse { get; set; } = new();
	[SectionPosition(11)] public List<TPB_BusinessProfessionalTitle> BusinessProfessionalTitle { get; set; } = new();
	[SectionPosition(12)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(13)] public List<LHL__LNM1_LAMT> LAMT {get;set;} = new();
	[SectionPosition(14)] public List<LHL__LNM1_LNX2> LNX2 {get;set;} = new();
	[SectionPosition(15)] public List<LHL__LNM1_LREF> LREF {get;set;} = new();
	[SectionPosition(16)] public List<LHL__LNM1_LLX> LLX {get;set;} = new();
	[SectionPosition(17)] public List<LHL__LNM1_LLM> LLM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.PropertyOrEntityIdentification, 0, 2);
		validator.CollectionSize(x => x.AdditionalNameInformation, 1, 2147483647);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.GeographicLocation, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.PercentAmounts, 1, 2147483647);
		validator.CollectionSize(x => x.LanguageUse, 1, 2147483647);
		validator.CollectionSize(x => x.BusinessProfessionalTitle, 1, 2147483647);
		validator.CollectionSize(x => x.Paperwork, 1, 2147483647);
		validator.CollectionSize(x => x.LAMT, 1, 2147483647);
		validator.CollectionSize(x => x.LNX2, 1, 2147483647);
		validator.CollectionSize(x => x.LREF, 1, 2147483647);
		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNX2) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
