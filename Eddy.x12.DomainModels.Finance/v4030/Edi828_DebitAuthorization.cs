using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;
using Eddy.x12.DomainModels.Finance.v4030._828;

namespace Eddy.x12.DomainModels.Finance.v4030;

public class Edi828_DebitAuthorization {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BAU_BeginningSegmentForTheDebitAuthorization BeginningSegmentForTheDebitAuthorization { get; set; } = new();
	[SectionPosition(3)] public N1_Name? Name { get; set; }
	[SectionPosition(4)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(5)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(6)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(7)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(8)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();

	//Details
	[SectionPosition(9)] public List<LDAD> LDAD {get;set;} = new();

	//Summary
	[SectionPosition(10)] public CTT_TransactionTotals TransactionTotals { get; set; } = new();
	[SectionPosition(11)] public AMT_MonetaryAmount? MonetaryAmount { get; set; }
	[SectionPosition(12)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi828_DebitAuthorization>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForTheDebitAuthorization);
		validator.CollectionSize(x => x.AdditionalNameInformation, 1, 2147483647);
		validator.CollectionSize(x => x.AddressInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		

		validator.CollectionSize(x => x.LDAD, 1, 2147483647);
		foreach (var item in LDAD) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionTotals);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
