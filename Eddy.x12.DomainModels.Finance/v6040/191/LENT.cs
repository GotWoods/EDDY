using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Finance.v6040._191;

public class LENT {
	[SectionPosition(1)] public ENT_Entity Entity { get; set; } = new();
	[SectionPosition(2)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(6)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(7)] public DMA_AdditionalDemographicInformation? AdditionalDemographicInformation { get; set; }
	[SectionPosition(8)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(9)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(10)] public ENR_SchoolEnrollmentInformation? SchoolEnrollmentInformation { get; set; }
	[SectionPosition(11)] public List<LENT_LIN1> LIN1 {get;set;} = new();
	[SectionPosition(12)] public List<LENT_LREF> LREF {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT>(this);
		validator.Required(x => x.Entity);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 0, 5);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 3);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 5);
		validator.CollectionSize(x => x.LIN1, 0, 10);
		validator.CollectionSize(x => x.LREF, 1, 100);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
