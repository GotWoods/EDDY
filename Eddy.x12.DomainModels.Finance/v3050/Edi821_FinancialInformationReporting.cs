using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;
using Eddy.x12.DomainModels.Finance.v3050._821;

namespace Eddy.x12.DomainModels.Finance.v3050;

public class Edi821_FinancialInformationReporting {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B2A_SetPurpose SetPurpose { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<TRN_Trace> Trace { get; set; } = new();
	[SectionPosition(5)] public N1_Name? Name { get; set; }
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(7)] public List<MSG_MessageText> MessageText { get; set; } = new();

	//Details
	[SectionPosition(8)] public List<LENT> LENT {get;set;} = new();

	//Summary
	[SectionPosition(9)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi821_FinancialInformationReporting>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.SetPurpose);
		validator.CollectionSize(x => x.DateTimeReference, 1, 4);
		validator.CollectionSize(x => x.Trace, 1, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		

		validator.CollectionSize(x => x.LENT, 1, 2147483647);
		foreach (var item in LENT) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
