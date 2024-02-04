using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._285;

public class LNX1_LLM {
	[SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; } = new();
	[SectionPosition(2)] public LQ_IndustryCode IndustryCode { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(6)] public DMA_AdditionalDemographicInformation? AdditionalDemographicInformation { get; set; }
	[SectionPosition(7)] public DVI_DynamicVehicleInformation? DynamicVehicleInformation { get; set; }
	[SectionPosition(8)] public VC1_VehicleDetail? VehicleDetail { get; set; }
	[SectionPosition(9)] public VEH_VehicleInformation? VehicleInformation { get; set; }
	[SectionPosition(10)] public List<LNX1__LLM_LNM1> LNM1 {get;set;} = new();
	[SectionPosition(11)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(12)] public List<LNX1__LLM_LLM> LLM {get;set;} = new();
	[SectionPosition(13)] public LE_LoopTrailer? LoopTrailer { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNX1_LLM>(this);
		validator.Required(x => x.CodeSourceInformation);
		validator.Required(x => x.IndustryCode);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
