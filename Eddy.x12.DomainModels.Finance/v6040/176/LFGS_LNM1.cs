using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Finance.v6040._176;

public class LFGS_LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(7)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(8)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(9)] public PCT_PercentAmounts? PercentAmounts { get; set; }
	[SectionPosition(10)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(11)] public List<LFGS__LNM1_LBBC> LBBC {get;set;} = new();
	[SectionPosition(12)] public List<LFGS__LNM1_LDTM> LDTM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LFGS_LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.AdditionalNameInformation, 1, 2147483647);
		validator.CollectionSize(x => x.PartyLocation, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.LBBC, 1, 2147483647);
		validator.CollectionSize(x => x.LDTM, 1, 2147483647);
		foreach (var item in LBBC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LDTM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
