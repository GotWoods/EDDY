using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Finance.v4060._260;

public class L0200 {
	[SectionPosition(1)] public CSI_ClaimStatusInformation ClaimStatusInformation { get; set; } = new();
	[SectionPosition(2)] public List<NM1_IndividualOrOrganizationalName> IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public N3_PartyLocation PartyLocation { get; set; } = new();
	[SectionPosition(5)] public N4_GeographicLocation GeographicLocation { get; set; } = new();
	[SectionPosition(6)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(7)] public List<INT_Interest> Interest { get; set; } = new();
	[SectionPosition(8)] public MIR_MortgageInsuranceResponse? MortgageInsuranceResponse { get; set; }
	[SectionPosition(9)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(10)] public PCT_PercentAmounts? PercentAmounts { get; set; }
	[SectionPosition(11)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(12)] public List<L0200_L0210> L0210 {get;set;} = new();
	[SectionPosition(13)] public List<L0200_L0220> L0220 {get;set;} = new();
	[SectionPosition(14)] public List<L0200_L0230> L0230 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.ClaimStatusInformation);
		validator.CollectionSize(x => x.IndividualOrOrganizationalName, 1, 2);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 6);
		validator.Required(x => x.PartyLocation);
		validator.Required(x => x.GeographicLocation);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 2);
		validator.CollectionSize(x => x.Interest, 0, 24);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 30);
		validator.CollectionSize(x => x.L0230, 1, 2147483647);
		foreach (var item in L0210) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0220) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0230) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
