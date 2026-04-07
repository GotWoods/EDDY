using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Finance.v5020._113;

public class LHL_LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(6)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(8)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(9)] public List<EMS_EmploymentPosition> EmploymentPosition { get; set; } = new();
	[SectionPosition(10)] public List<TPB_BusinessProfessionalTitle> BusinessProfessionalTitle { get; set; } = new();
	[SectionPosition(11)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(12)] public List<PAM_PeriodAmount> PeriodAmount { get; set; } = new();
	[SectionPosition(13)] public G86_SignatureIdentification? SignatureIdentification { get; set; }
	[SectionPosition(14)] public List<MTX_Text> Text { get; set; } = new();
	[SectionPosition(15)] public List<LHL__LNM1_LLQ> LLQ {get;set;} = new();
	[SectionPosition(16)] public List<LHL__LNM1_LAWD> LAWD {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.LocationIDComponent, 1, 2147483647);
		validator.CollectionSize(x => x.EmploymentPosition, 1, 2147483647);
		validator.CollectionSize(x => x.BusinessProfessionalTitle, 1, 2147483647);
		validator.CollectionSize(x => x.Paperwork, 1, 2147483647);
		validator.CollectionSize(x => x.PeriodAmount, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		validator.CollectionSize(x => x.LLQ, 1, 2147483647);
		validator.CollectionSize(x => x.LAWD, 1, 2147483647);
		foreach (var item in LLQ) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LAWD) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
