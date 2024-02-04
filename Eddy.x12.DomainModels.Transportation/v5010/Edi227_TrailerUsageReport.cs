using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;
using Eddy.x12.DomainModels.Transportation.v5010._227;

namespace Eddy.x12.DomainModels.Transportation.v5010;

public class Edi227_TrailerUsageReport {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BLR_TransportationCarrierIdentification TransportationCarrierIdentification { get; set; } = new();
	[SectionPosition(3)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi227_TrailerUsageReport>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransportationCarrierIdentification);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 1, 2147483647);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
