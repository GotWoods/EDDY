using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._262;

public class LLX_LIN1 {
	[SectionPosition(1)] public IN1_IndividualIdentification IndividualIdentification { get; set; } = new();
	[SectionPosition(2)] public IN2_IndividualNameStructureComponents IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(3)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(6)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(7)] public List<LLX__LIN1_LYNQ> LYNQ {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LIN1>(this);
		validator.Required(x => x.IndividualIdentification);
		validator.Required(x => x.IndividualNameStructureComponents);
		validator.CollectionSize(x => x.AddressInformation, 0, 10);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 2);
		validator.CollectionSize(x => x.LYNQ, 1, 50);
		foreach (var item in LYNQ) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
