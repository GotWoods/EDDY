using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;
using Eddy.x12.DomainModels.Transportation.v3050._455;

namespace Eddy.x12.DomainModels.Transportation.v3050;

public class Edi455_RailroadParameterTraceRegistration {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BTC_BeginningSegmentForParameterTraceRegistration BeginningSegmentForParameterTraceRegistration { get; set; } = new();
	[SectionPosition(3)] public DTP_DateOrTimeOrPeriod DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public PRM_BasicTraceParameters? BasicTraceParameters { get; set; }
	[SectionPosition(5)] public ED_EquipmentDescription? EquipmentDescription { get; set; }
	[SectionPosition(6)] public List<BLR_TransportationCarrierIdentification> TransportationCarrierIdentification { get; set; } = new();
	[SectionPosition(7)] public N9_ReferenceNumber? ReferenceNumber { get; set; }
	[SectionPosition(8)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(9)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi455_RailroadParameterTraceRegistration>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForParameterTraceRegistration);
		validator.Required(x => x.DateOrTimeOrPeriod);
		validator.CollectionSize(x => x.TransportationCarrierIdentification, 0, 5);
		validator.CollectionSize(x => x.EventDetail, 0, 99);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
