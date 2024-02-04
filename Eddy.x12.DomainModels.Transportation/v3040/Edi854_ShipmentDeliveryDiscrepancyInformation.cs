using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;
using Eddy.x12.DomainModels.Transportation.v3040._854;

namespace Eddy.x12.DomainModels.Transportation.v3040;

public class Edi854_ShipmentDeliveryDiscrepancyInformation {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B10_BeginningSegmentForShipmentStatusMessage BeginningSegmentForShipmentStatusMessage { get; set; } = new();
	[SectionPosition(3)] public G62_DateTime? DateTime { get; set; }
	[SectionPosition(4)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(5)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(6)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(7)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(8)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi854_ShipmentDeliveryDiscrepancyInformation>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShipmentStatusMessage);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 20);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		

		validator.CollectionSize(x => x.LN1, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLX, 1, 999);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
