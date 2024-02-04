using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050;

public class Edi440_ShipmentWeights {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BW_BeginningSegmentForWeightMessageSet BeginningSegmentForWeightMessageSet { get; set; } = new();
	[SectionPosition(3)] public G4_ScaleIdentification? ScaleIdentification { get; set; }
	[SectionPosition(4)] public List<G5_ScaleInformation> ScaleInformation { get; set; } = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi440_ShipmentWeights>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForWeightMessageSet);
		validator.CollectionSize(x => x.ScaleInformation, 1, 255);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
