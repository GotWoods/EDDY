using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;
using Eddy.x12.DomainModels.Transportation.v6050._432;

namespace Eddy.x12.DomainModels.Transportation.v6050;

public class Edi432_RailDeprescription {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public BLR_TransportationCarrierIdentification TransportationCarrierIdentification { get; set; } = new();
	[SectionPosition(4)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(6)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(7)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi432_RailDeprescription>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.TransportationCarrierIdentification);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.DateTimeReference, 0, 6);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLX, 0, 10);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
