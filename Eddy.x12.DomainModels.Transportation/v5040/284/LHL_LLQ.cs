using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Transportation.v5040._284;

public class LHL_LLQ {
	[SectionPosition(1)] public LQ_IndustryCodeIdentification IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(2)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(4)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(5)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(6)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(7)] public LOD_LocationDescription? LocationDescription { get; set; }
	[SectionPosition(8)] public SRE_TestScores? TestScores { get; set; }
	[SectionPosition(9)] public VEH_VehicleInformation? VehicleInformation { get; set; }
	[SectionPosition(10)] public List<DVI_DynamicVehicleInformation> DynamicVehicleInformation { get; set; } = new();
	[SectionPosition(11)] public List<LHL__LLQ_LAMT> LAMT {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LLQ>(this);
		validator.Required(x => x.IndustryCodeIdentification);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		validator.CollectionSize(x => x.DynamicVehicleInformation, 1, 2147483647);
		validator.CollectionSize(x => x.LAMT, 1, 2147483647);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
