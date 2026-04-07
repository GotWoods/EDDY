using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3010;
using Eddy.x12.DomainModels.Finance.v3010._826;

namespace Eddy.x12.DomainModels.Finance.v3010;

public class Edi826_TaxInformationReporting {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BTI_BeginningTaxInformation BeginningTaxInformation { get; set; } = new();
	[SectionPosition(3)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(4)] public List<LTFS> LTFS {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi826_TaxInformationReporting>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningTaxInformation);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 1, 2);
		validator.CollectionSize(x => x.LTFS, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTFS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
