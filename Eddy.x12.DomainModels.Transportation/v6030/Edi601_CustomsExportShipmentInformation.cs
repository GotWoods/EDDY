using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;
using Eddy.x12.DomainModels.Transportation.v6030._601;

namespace Eddy.x12.DomainModels.Transportation.v6030;

public class Edi601_CustomsExportShipmentInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<LBA1> LBA1 {get;set;} = new();
	[SectionPosition(3)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi601_CustomsExportShipmentInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LBA1, 1, 999);
		foreach (var item in LBA1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
