using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Transportation.v3030._114;

namespace Eddy.x12.DomainModels.Transportation.v3030;

public class Edi114_AirShipmentStatusMessage {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public B10_BeginningSegmentForShipmentStatusMessage BeginningSegmentForShipmentStatusMessage { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(5)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(6)] public List<R1_RouteInformationAir> RouteInformationAir { get; set; } = new();

	//Details
	[SectionPosition(7)] public List<LQ5> LQ5 {get;set;} = new();

	//Summary
	[SectionPosition(8)] public List<ACS_AncillaryCharges> AncillaryCharges { get; set; } = new();
	[SectionPosition(9)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi114_AirShipmentStatusMessage>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForShipmentStatusMessage);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 20);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.RouteInformationAir, 0, 12);
		

		validator.CollectionSize(x => x.LN1, 0, 10);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LQ5, 1, 20);
		foreach (var item in LQ5) validator.Results.AddRange(item.Validate().Errors);
		validator.CollectionSize(x => x.AncillaryCharges, 0, 20);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
