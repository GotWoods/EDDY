using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;
using Eddy.x12.DomainModels.Transportation.v3070._440;

namespace Eddy.x12.DomainModels.Transportation.v3070;

public class Edi440_ShipmentWeights {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BW_BeginningSegmentForWeightMessageSet BeginningSegmentForWeightMessageSet { get; set; } = new();
	[SectionPosition(3)] public G4_ScaleIdentification? ScaleIdentification { get; set; }
	[SectionPosition(4)] public List<G5_WeightInformation> WeightInformation { get; set; } = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi440_ShipmentWeights>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForWeightMessageSet);
		validator.CollectionSize(x => x.WeightInformation, 1, 255);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}