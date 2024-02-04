using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;
using Eddy.x12.DomainModels.Transportation.v7020._214;

namespace Eddy.x12.DomainModels.Transportation.v7020;

public class Edi214_TransportationCarrierShipmentStatusMessage {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage BeginningSegmentForTransportationCarrierShipmentStatusMessage { get; set; } = new();
	[SectionPosition(3)] public List<MS3_InterlineInformation> InterlineInformation { get; set; } = new();

	//Details
	[SectionPosition(4)] public List<L1000> L1000 {get;set;} = new();
	[SectionPosition(5)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi214_TransportationCarrierShipmentStatusMessage>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForTransportationCarrierShipmentStatusMessage);
		validator.CollectionSize(x => x.InterlineInformation, 0, 12);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L1000, 1, 999999);
		foreach (var item in L1000) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
