using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;
using Eddy.x12.DomainModels.Transportation.v3040._214;

namespace Eddy.x12.DomainModels.Transportation.v3040;

public class Edi214_TransportationCarrierShipmentStatusMessage {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B10_BeginningSegmentForShipmentStatusMessage BeginningSegmentForShipmentStatusMessage { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(5)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(6)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(7)] public List<R3_RouteInformationMotor> RouteInformationMotor { get; set; } = new();
	[SectionPosition(8)] public List<L0200> L0200 {get;set;} = new();
	[SectionPosition(9)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi214_TransportationCarrierShipmentStatusMessage>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShipmentStatusMessage);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 300);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 300);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.RouteInformationMotor, 0, 12);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 0, 10);
		validator.CollectionSize(x => x.L0200, 0, 20);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
