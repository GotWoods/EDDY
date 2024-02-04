using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Transportation.v6010._285;

public class LNX1_LLM {
	[SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; } = new();
	[SectionPosition(2)] public LQ_IndustryCodeIdentification IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(6)] public DMA_AdditionalDemographicInformation? AdditionalDemographicInformation { get; set; }
	[SectionPosition(7)] public List<DVI_DynamicVehicleInformation> DynamicVehicleInformation { get; set; } = new();
	[SectionPosition(8)] public VC1_VehicleDetail? VehicleDetail { get; set; }
	[SectionPosition(9)] public VEH_VehicleInformation? VehicleInformation { get; set; }
	[SectionPosition(10)] public N12_EquipmentEnvironment? EquipmentEnvironment { get; set; }
	[SectionPosition(11)] public List<LNX1__LLM_LNM1> LNM1 {get;set;} = new();
	[SectionPosition(12)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(13)] public List<LNX1__LLM_LLM> LLM {get;set;} = new();
	[SectionPosition(14)] public LE_LoopTrailer? LoopTrailer { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNX1_LLM>(this);
		validator.Required(x => x.CodeSourceInformation);
		validator.Required(x => x.IndustryCodeIdentification);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.DynamicVehicleInformation, 1, 2147483647);
		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
