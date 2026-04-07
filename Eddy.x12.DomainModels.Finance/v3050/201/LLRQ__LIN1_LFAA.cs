using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._201;

public class LLRQ__LIN1_LFAA {
	[SectionPosition(1)] public FAA_FinancialAssetAccount FinancialAssetAccount { get; set; } = new();
	[SectionPosition(2)] public N1_Name Name { get; set; } = new();
	[SectionPosition(3)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(4)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(7)] public MSG_MessageText? MessageText { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLRQ__LIN1_LFAA>(this);
		validator.Required(x => x.FinancialAssetAccount);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		return validator.Results;
	}
}
