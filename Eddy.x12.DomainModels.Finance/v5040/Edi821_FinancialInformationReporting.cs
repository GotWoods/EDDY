using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;
using Eddy.x12.DomainModels.Finance.v5040._821;

namespace Eddy.x12.DomainModels.Finance.v5040;

public class Edi821_FinancialInformationReporting {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B2A_SetPurpose SetPurpose { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<TRN_Trace> Trace { get; set; } = new();
	[SectionPosition(5)] public List<N1_PartyIdentification> PartyIdentification { get; set; } = new();
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(7)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(8)] public List<LLM> LLM {get;set;} = new();
	[SectionPosition(9)] public List<LFA1> LFA1 {get;set;} = new();

	//Details
	[SectionPosition(10)] public List<LENT> LENT {get;set;} = new();

	//Summary
	[SectionPosition(11)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi821_FinancialInformationReporting>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.SetPurpose);
		validator.CollectionSize(x => x.DateTimeReference, 1, 4);
		validator.CollectionSize(x => x.Trace, 1, 2);
		validator.CollectionSize(x => x.PartyIdentification, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		

		validator.CollectionSize(x => x.LLM, 0, 10);
		validator.CollectionSize(x => x.LFA1, 1, 2147483647);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LFA1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LENT, 1, 2147483647);
		foreach (var item in LENT) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
