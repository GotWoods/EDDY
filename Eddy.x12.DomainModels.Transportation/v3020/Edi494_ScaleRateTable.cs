using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020;

public class Edi494_ScaleRateTable {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public PRI_ExternalReferenceIdentifier ExternalReferenceIdentifier { get; set; } = new();
	[SectionPosition(3)] public SRC_ScaleRateColumnID ScaleRateColumnID { get; set; } = new();
	[SectionPosition(4)] public List<SRD_ScaleRateDetail> ScaleRateDetail { get; set; } = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi494_ScaleRateTable>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.ExternalReferenceIdentifier);
		validator.Required(x => x.ScaleRateColumnID);
		validator.CollectionSize(x => x.ScaleRateDetail, 1, 200);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
