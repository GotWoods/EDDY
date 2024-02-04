using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;
using Eddy.x12.DomainModels.Transportation.v6040._317;

namespace Eddy.x12.DomainModels.Transportation.v6040;

public class Edi317_DeliveryPickupOrder {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(3)] public G62_DateTime DateTime { get; set; } = new();
	[SectionPosition(4)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public TD5_CarrierDetailsRoutingSequenceTransitTime CarrierDetailsRoutingSequenceTransitTime { get; set; } = new();
	[SectionPosition(6)] public List<LL0> LL0 {get;set;} = new();
	[SectionPosition(7)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi317_DeliveryPickupOrder>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.DateTime);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 9);
		validator.Required(x => x.CarrierDetailsRoutingSequenceTransitTime);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 1, 10);
		validator.CollectionSize(x => x.LL0, 1, 9999);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LL0) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
