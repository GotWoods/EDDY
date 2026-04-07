using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._201;

public class LLRQ__LIN1_LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(6)] public YNQ_YesNoQuestion? YesNoQuestion { get; set; }
	[SectionPosition(7)] public EMS_EmploymentPosition? EmploymentPosition { get; set; }
	[SectionPosition(8)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(9)] public AMT_MonetaryAmount? MonetaryAmount { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLRQ__LIN1_LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		validator.CollectionSize(x => x.Quantity, 1, 2147483647);
		return validator.Results;
	}
}
