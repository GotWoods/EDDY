using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;
using Eddy.x12.DomainModels.Transportation.v7010._455;

namespace Eddy.x12.DomainModels.Transportation.v7010;

public class Edi455_RailroadParameterTraceRegistration {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BTC_BeginningSegmentForParameterTraceRegistration BeginningSegmentForParameterTraceRegistration { get; set; } = new();
	[SectionPosition(3)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(4)] public List<ED_EquipmentDescription> EquipmentDescription { get; set; } = new();
	[SectionPosition(5)] public List<BLR_TransportationCarrierIdentification> TransportationCarrierIdentification { get; set; } = new();
	[SectionPosition(6)] public N9_ExtendedReferenceInformation? ExtendedReferenceInformation { get; set; }
	[SectionPosition(7)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(8)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(9)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi455_RailroadParameterTraceRegistration>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForParameterTraceRegistration);
		validator.CollectionSize(x => x.EquipmentDescription, 0, 500000);
		validator.CollectionSize(x => x.TransportationCarrierIdentification, 0, 5);
		validator.CollectionSize(x => x.EventDetail, 0, 99);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLX, 0, 99);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
