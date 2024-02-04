using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;
using Eddy.x12.DomainModels.Transportation.v3070._214;

namespace Eddy.x12.DomainModels.Transportation.v3070;

public class Edi214_TransportationCarrierShipmentStatusMessage {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage BeginningSegmentForTransportationCarrierShipmentStatusMessage { get; set; } = new();
	[SectionPosition(3)] public List<L11_BusinessInstructions> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(5)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(6)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(7)] public List<MS3_InterlineInformation> InterlineInformation { get; set; } = new();
	[SectionPosition(8)] public List<L0200> L0200 {get;set;} = new();
	[SectionPosition(9)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi214_TransportationCarrierShipmentStatusMessage>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForTransportationCarrierShipmentStatusMessage);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 300);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 9999);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.InterlineInformation, 0, 12);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 0, 10);
		validator.CollectionSize(x => x.L0200, 0, 999999);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
