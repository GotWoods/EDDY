using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;
using Eddy.x12.DomainModels.Transportation.v3060._120;

namespace Eddy.x12.DomainModels.Transportation.v3060;

public class Edi120_VehicleShippingOrder {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BVP_BeginningSegmentForVehicleShippingOrder BeginningSegmentForVehicleShippingOrder { get; set; } = new();
	[SectionPosition(3)] public List<LG62> LG62 {get;set;} = new();
	[SectionPosition(4)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Details

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi120_VehicleShippingOrder>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForVehicleShippingOrder);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LG62, 1, 99);
		foreach (var item in LG62) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
