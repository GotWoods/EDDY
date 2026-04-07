using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;
using Eddy.x12.DomainModels.Finance.v3060._822;

namespace Eddy.x12.DomainModels.Finance.v3060;

public class Edi822_CustomerAccountAnalysis {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public N1_Name? Name { get; set; }
	[SectionPosition(5)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(6)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(7)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(8)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(9)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(10)] public List<LRTE> LRTE {get;set;} = new();

	//Details
	[SectionPosition(11)] public List<LENT> LENT {get;set;} = new();
	[SectionPosition(12)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi822_CustomerAccountAnalysis>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.DateTimeReference, 1, 3);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		

		validator.CollectionSize(x => x.LRTE, 1, 2147483647);
		foreach (var item in LRTE) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LENT, 1, 2147483647);
		foreach (var item in LENT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
