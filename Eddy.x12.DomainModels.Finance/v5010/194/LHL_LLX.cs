using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Finance.v5010._194;

public class LHL_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public NM1_IndividualOrOrganizationalName? IndividualOrOrganizationalName { get; set; }
	[SectionPosition(3)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(4)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(7)] public List<DMG_DemographicInformation> DemographicInformation { get; set; } = new();
	[SectionPosition(8)] public EMS_EmploymentPosition? EmploymentPosition { get; set; }
	[SectionPosition(9)] public List<LHL__LLX_LN9> LN9 {get;set;} = new();
	[SectionPosition(10)] public List<LHL__LLX_LDEG> LDEG {get;set;} = new();
	[SectionPosition(11)] public List<LHL__LLX_LK2> LK2 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.DemographicInformation, 1, 2147483647);
		validator.CollectionSize(x => x.LN9, 1, 2147483647);
		validator.CollectionSize(x => x.LDEG, 1, 2147483647);
		validator.CollectionSize(x => x.LK2, 1, 2147483647);
		foreach (var item in LN9) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LDEG) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LK2) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
