using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._201;

public class LLRQ__LIN1_LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(6)] public List<ACT_AccountIdentification> AccountIdentification { get; set; } = new();
	[SectionPosition(7)] public YNQ_YesNoQuestion? YesNoQuestion { get; set; }
	[SectionPosition(8)] public EMS_EmploymentPosition? EmploymentPosition { get; set; }
	[SectionPosition(9)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(10)] public AMT_MonetaryAmount? MonetaryAmount { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLRQ__LIN1_LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		validator.CollectionSize(x => x.AccountIdentification, 0, 10);
		validator.CollectionSize(x => x.Quantity, 0, 2);
		return validator.Results;
	}
}
