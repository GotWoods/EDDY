using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Finance.v7060._262;

public class L2000_L2200 {
	[SectionPosition(1)] public IN1_IndividualIdentification IndividualIdentification { get; set; } = new();
	[SectionPosition(2)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(6)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(7)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(8)] public List<L2000__L2200_L2210> L2210 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000_L2200>(this);
		validator.Required(x => x.IndividualIdentification);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 1, 10);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 2);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.L2210, 0, 10);
		foreach (var item in L2210) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
