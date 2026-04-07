using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Finance.v6040._264;

public class L0200 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(4)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(5)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(6)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(7)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(8)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(9)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(10)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(11)] public List<L0200_L0210> L0210 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.DateTimeReference, 0, 2);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 2);
		validator.CollectionSize(x => x.QuantityInformation, 0, 2);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 2);
		validator.CollectionSize(x => x.L0210, 1, 2147483647);
		foreach (var item in L0210) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
