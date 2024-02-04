using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._212;

public class L0200 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public BLR_TransportationCarrierIdentification? TransportationCarrierIdentification { get; set; }
	[SectionPosition(4)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(5)] public AT8_ShipmentWeightPackagingAndQuantityData? ShipmentWeightPackagingAndQuantityData { get; set; }
	[SectionPosition(6)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(7)] public TSD_TrailerShipmentDetails? TrailerShipmentDetails { get; set; }
	[SectionPosition(8)] public List<L0200_L0210> L0210 {get;set;} = new();
	[SectionPosition(9)] public List<L0200_L0220> L0220 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 9999);
		validator.CollectionSize(x => x.DateTime, 0, 5);
		validator.CollectionSize(x => x.L0210, 0, 999999);
		foreach (var item in L0210) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0220) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
