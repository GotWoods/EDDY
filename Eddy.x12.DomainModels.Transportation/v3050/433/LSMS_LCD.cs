using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._433;

public class LSMS_LCD {
	[SectionPosition(1)] public CD_ShipmentConditions ShipmentConditions { get; set; } = new();
	[SectionPosition(2)] public List<SID_StandardTransportationCommodityCodeIdentification> StandardTransportationCommodityCodeIdentification { get; set; } = new();
	[SectionPosition(3)] public List<BLR_TransportationCarrierIdentification> TransportationCarrierIdentification { get; set; } = new();
	[SectionPosition(4)] public List<N4_GeographicLocation> GeographicLocation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSMS_LCD>(this);
		validator.Required(x => x.ShipmentConditions);
		validator.CollectionSize(x => x.StandardTransportationCommodityCodeIdentification, 0, 2);
		validator.CollectionSize(x => x.TransportationCarrierIdentification, 0, 20);
		validator.CollectionSize(x => x.GeographicLocation, 0, 50);
		return validator.Results;
	}
}
