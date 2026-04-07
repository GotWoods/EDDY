using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;
using Eddy.x12.DomainModels.Finance.v3040._822;

namespace Eddy.x12.DomainModels.Finance.v3040;

public class Edi822_CustomerAccountAnalysis {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public N1_Name Name { get; set; } = new();
	[SectionPosition(5)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(6)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(7)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(8)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(9)] public List<LRTE> LRTE {get;set;} = new();
	[SectionPosition(10)] public CUR_Currency? Currency { get; set; }

	//Details
	[SectionPosition(11)] public List<LN1> LN1 {get;set;} = new();

	//Summary
	[SectionPosition(12)] public CTT_TransactionTotals TransactionTotals { get; set; } = new();
	[SectionPosition(13)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi822_CustomerAccountAnalysis>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.DateTimeReference, 1, 3);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		

		validator.CollectionSize(x => x.LRTE, 0, 13);
		foreach (var item in LRTE) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LN1, 1, 500);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionTotals);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
