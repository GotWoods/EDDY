using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;
using Eddy.x12.DomainModels.Transportation.v4010._163;

namespace Eddy.x12.DomainModels.Transportation.v4010;

public class Edi163_TransportationAppointmentScheduleInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B13_BeginningSegmentForAppointmentSchedule BeginningSegmentForAppointmentSchedule { get; set; } = new();
	[SectionPosition(3)] public B2A_SetPurpose SetPurpose { get; set; } = new();
	[SectionPosition(4)] public List<H6_SpecialServices> SpecialServices { get; set; } = new();
	[SectionPosition(5)] public List<N7_EquipmentDetails> EquipmentDetails { get; set; } = new();
	[SectionPosition(6)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(7)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(8)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(9)] public G05_TotalShipmentInformation? TotalShipmentInformation { get; set; }
	[SectionPosition(10)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(11)] public List<L0300> L0300 {get;set;} = new();
	[SectionPosition(12)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi163_TransportationAppointmentScheduleInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForAppointmentSchedule);
		validator.Required(x => x.SetPurpose);
		validator.CollectionSize(x => x.SpecialServices, 0, 5);
		validator.CollectionSize(x => x.EquipmentDetails, 0, 3);
		validator.CollectionSize(x => x.DateTime, 0, 10);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 999);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0100, 0, 3);
		validator.CollectionSize(x => x.L0300, 0, 999);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0300) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
