using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Finance.v3030._828;

namespace Eddy.x12.DomainModels.Finance.v3030;

public class Edi828_DebitAuthorization {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BAU_BeginningSegmentForTheDebitAuthorization BeginningSegmentForTheDebitAuthorization { get; set; } = new();
	[SectionPosition(3)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(4)] public List<DAD_DebitAuthorizationDetail> DebitAuthorizationDetail { get; set; } = new();
	[SectionPosition(5)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(6)] public CTT_TransactionTotals TransactionTotals { get; set; } = new();
	[SectionPosition(7)] public AMT_MonetaryAmount? MonetaryAmount { get; set; }
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi828_DebitAuthorization>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForTheDebitAuthorization);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.DebitAuthorizationDetail, 1, 999990);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionTotals);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
