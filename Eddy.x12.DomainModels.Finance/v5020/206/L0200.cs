using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Finance.v5020._206;

public class L0200 {
	[SectionPosition(1)] public SI_ServiceCharacteristicIdentification ServiceCharacteristicIdentification { get; set; } = new();
	[SectionPosition(2)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public RLT_RealEstateLoanType? RealEstateLoanType { get; set; }
	[SectionPosition(4)] public REC_RealEstateCondition? RealEstateCondition { get; set; }
	[SectionPosition(5)] public LN_LoanInformation? LoanInformation { get; set; }
	[SectionPosition(6)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(7)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(8)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(9)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(10)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(11)] public CTP_PricingInformation? PricingInformation { get; set; }
	[SectionPosition(12)] public List<L0200_L0210> L0210 {get;set;} = new();
	[SectionPosition(13)] public List<L0200_L0220> L0220 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.ServiceCharacteristicIdentification);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 2);
		validator.CollectionSize(x => x.Paperwork, 0, 5);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 2);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 20);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 5);
		validator.CollectionSize(x => x.L0210, 1, 2147483647);
		validator.CollectionSize(x => x.L0220, 1, 2147483647);
		foreach (var item in L0210) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0220) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
