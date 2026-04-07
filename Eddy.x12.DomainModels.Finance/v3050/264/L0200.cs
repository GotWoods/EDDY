using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._264;

public class L0200 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(3)] public N1_Name? Name { get; set; }
	[SectionPosition(4)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(5)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(6)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(7)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(8)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(9)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(10)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(11)] public List<L0200_L0210> L0210 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2);
		validator.CollectionSize(x => x.Quantity, 0, 2);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 2);
		validator.CollectionSize(x => x.L0210, 1, 2147483647);
		foreach (var item in L0210) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
