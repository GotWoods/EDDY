using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;
using Eddy.x12.DomainModels.Transportation.v8040._350;

namespace Eddy.x12.DomainModels.Transportation.v8040;

public class Edi350_CustomsStatusInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public M10_ManifestIdentifyingInformation? ManifestIdentifyingInformation { get; set; }
	[SectionPosition(3)] public List<LP4> LP4 {get;set;} = new();
	[SectionPosition(4)] public List<LBA1> LBA1 {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi350_CustomsStatusInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LP4, 0, 20);
		validator.CollectionSize(x => x.LBA1, 0, 999);
		foreach (var item in LP4) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LBA1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
