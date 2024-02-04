using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;
using Eddy.x12.DomainModels.Transportation.v4050._355;

namespace Eddy.x12.DomainModels.Transportation.v4050;

public class Edi355_USCustomsAcceptanceRejection {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public M10_ManifestIdentifyingInformation ManifestIdentifyingInformation { get; set; } = new();
	[SectionPosition(3)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(4)] public List<LP4> LP4 {get;set;} = new();

	//Details
	[SectionPosition(5)] public K3_FileInformation FileInformation { get; set; } = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi355_USCustomsAcceptanceRejection>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.ManifestIdentifyingInformation);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		

		validator.CollectionSize(x => x.LP4, 1, 20);
		foreach (var item in LP4) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.FileInformation);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
