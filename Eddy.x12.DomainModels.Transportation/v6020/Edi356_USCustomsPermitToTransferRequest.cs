using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;
using Eddy.x12.DomainModels.Transportation.v6020._356;

namespace Eddy.x12.DomainModels.Transportation.v6020;

public class Edi356_USCustomsPermitToTransferRequest {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public M10_ManifestIdentifyingInformation ManifestIdentifyingInformation { get; set; } = new();
	[SectionPosition(3)] public List<LP4> LP4 {get;set;} = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi356_USCustomsPermitToTransferRequest>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.ManifestIdentifyingInformation);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LP4, 1, 20);
		foreach (var item in LP4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
