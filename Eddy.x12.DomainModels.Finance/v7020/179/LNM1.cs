using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._179;

public class LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public List<N4_GeographicLocation> GeographicLocation { get; set; } = new();
	[SectionPosition(5)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public TPB_BusinessProfessionalTitle? BusinessProfessionalTitle { get; set; }
	[SectionPosition(7)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(8)] public G86_SignatureIdentification? SignatureIdentification { get; set; }
	[SectionPosition(9)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(10)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(11)] public List<LNM1_LLM> LLM {get;set;} = new();
	[SectionPosition(12)] public List<LNM1_LQTY> LQTY {get;set;} = new();
	[SectionPosition(13)] public List<LNM1_LOOI> LOOI {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.GeographicLocation, 1, 2147483647);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		validator.CollectionSize(x => x.LQTY, 1, 2147483647);
		validator.CollectionSize(x => x.LOOI, 1, 2147483647);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LQTY) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LOOI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
