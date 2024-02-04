using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;
using Eddy.x12.DomainModels.Transportation.v3060._214;

namespace Eddy.x12.DomainModels.Transportation.v3060;

public class Edi214_TransportationCarrierShipmentStatusMessage {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B10_BeginningSegmentForStatusDiscrepancyAndAppointmentSchedule BeginningSegmentForStatusDiscrepancyAndAppointmentSchedule { get; set; } = new();
	[SectionPosition(3)] public B2A_SetPurpose SetPurpose { get; set; } = new();
	[SectionPosition(4)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(5)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(6)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(7)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(8)] public List<R3_RouteInformationMotor> RouteInformationMotor { get; set; } = new();
	[SectionPosition(9)] public List<L0200> L0200 {get;set;} = new();
	[SectionPosition(10)] public List<L0400> L0400 {get;set;} = new();
	[SectionPosition(11)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi214_TransportationCarrierShipmentStatusMessage>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForStatusDiscrepancyAndAppointmentSchedule);
		validator.Required(x => x.SetPurpose);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 300);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 9999);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.RouteInformationMotor, 0, 12);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 0, 10);
		validator.CollectionSize(x => x.L0200, 0, 9999);
		validator.CollectionSize(x => x.L0400, 0, 999999);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0400) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
