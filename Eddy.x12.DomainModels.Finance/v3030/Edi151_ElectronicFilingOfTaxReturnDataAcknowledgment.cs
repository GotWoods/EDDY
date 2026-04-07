using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Finance.v3030._151;

namespace Eddy.x12.DomainModels.Finance.v3030;

public class Edi151_ElectronicFilingOfTaxReturnDataAcknowledgment {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BTA_BeginningTaxAcknowledgment BeginningTaxAcknowledgment { get; set; } = new();
	[SectionPosition(3)] public BTI_BeginningTaxInformation BeginningTaxInformation { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(5)] public List<PBI_ProblemIdentification> ProblemIdentification { get; set; } = new();

	//Details
	[SectionPosition(6)] public List<LTFS> LTFS {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi151_ElectronicFilingOfTaxReturnDataAcknowledgment>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningTaxAcknowledgment);
		validator.Required(x => x.BeginningTaxInformation);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 10);
		validator.CollectionSize(x => x.ProblemIdentification, 0, 1000);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LTFS, 0, 100000);
		foreach (var item in LTFS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
