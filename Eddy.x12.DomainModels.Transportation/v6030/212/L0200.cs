using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Transportation.v6030._212;

public class L0200 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public AT7_ShipmentStatusDetails? ShipmentStatusDetails { get; set; }
	[SectionPosition(4)] public BLR_TransportationCarrierIdentification? TransportationCarrierIdentification { get; set; }
	[SectionPosition(5)] public List<MAN_MarksAndNumbersInformation> MarksAndNumbersInformation { get; set; } = new();
	[SectionPosition(6)] public AT8_ShipmentWeightPackagingAndQuantityData? ShipmentWeightPackagingAndQuantityData { get; set; }
	[SectionPosition(7)] public List<Q7_LadingExceptionStatus> LadingExceptionStatus { get; set; } = new();
	[SectionPosition(8)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(9)] public TSD_TrailerShipmentDetails? TrailerShipmentDetails { get; set; }
	[SectionPosition(10)] public List<L0200_L0210> L0210 {get;set;} = new();
	[SectionPosition(11)] public List<L0200_L0220> L0220 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 300);
		validator.CollectionSize(x => x.MarksAndNumbersInformation, 0, 9999);
		validator.CollectionSize(x => x.LadingExceptionStatus, 0, 10);
		validator.CollectionSize(x => x.DateTime, 0, 5);
		validator.CollectionSize(x => x.L0210, 0, 999999);
		foreach (var item in L0210) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0220) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
