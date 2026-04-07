using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._201;

public class LLRQ__LIN1_LCDA {
	[SectionPosition(1)] public CDA_ConsumerCreditAccount ConsumerCreditAccount { get; set; } = new();
	[SectionPosition(2)] public YNQ_YesNoQuestion YesNoQuestion { get; set; } = new();
	[SectionPosition(3)] public N1_Name Name { get; set; } = new();
	[SectionPosition(4)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(5)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(6)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(7)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLRQ__LIN1_LCDA>(this);
		validator.Required(x => x.ConsumerCreditAccount);
		validator.Required(x => x.YesNoQuestion);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		return validator.Results;
	}
}
