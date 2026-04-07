using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._176;

public class LCDS_LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(6)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(7)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(8)] public List<LCDS__LNM1_LBBC> LBBC {get;set;} = new();
	[SectionPosition(9)] public List<LCDS__LNM1_LDTM> LDTM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCDS_LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.AdditionalNameInformation, 1, 2147483647);
		validator.CollectionSize(x => x.AddressInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.Quantity, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.LBBC, 1, 2147483647);
		validator.CollectionSize(x => x.LDTM, 1, 2147483647);
		foreach (var item in LBBC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LDTM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
