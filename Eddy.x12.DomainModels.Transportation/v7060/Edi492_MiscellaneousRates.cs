using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;
using Eddy.x12.DomainModels.Transportation.v7060._492;

namespace Eddy.x12.DomainModels.Transportation.v7060;

public class Edi492_MiscellaneousRates {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public DK_DocketHeader DocketHeader { get; set; } = new();
	[SectionPosition(3)] public PRI_ExternalReferenceIdentifier ExternalReferenceIdentifier { get; set; } = new();
	[SectionPosition(4)] public DM_DemurrageDetentionStorageRate? DemurrageDetentionStorageRate { get; set; }
	[SectionPosition(5)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(6)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi492_MiscellaneousRates>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.DocketHeader);
		validator.Required(x => x.ExternalReferenceIdentifier);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 0, 10);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
