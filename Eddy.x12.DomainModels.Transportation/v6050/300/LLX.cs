using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050._300;

public class LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public N7_EquipmentDetails? EquipmentDetails { get; set; }
	[SectionPosition(3)] public W09_EquipmentAndTemperature? EquipmentAndTemperature { get; set; }
	[SectionPosition(4)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(5)] public L0_LineItemQuantityAndWeight? LineItemQuantityAndWeight { get; set; }
	[SectionPosition(6)] public L5_DescriptionMarksAndNumbers? DescriptionMarksAndNumbers { get; set; }
	[SectionPosition(7)] public L4_Measurement? Measurement { get; set; }
	[SectionPosition(8)] public L1_RateAndCharges? RateAndCharges { get; set; }
	[SectionPosition(9)] public REF_ReferenceInformation? ReferenceInformation { get; set; }
	[SectionPosition(10)] public List<LLX_LH1> LH1 {get;set;} = new();
	[SectionPosition(11)] public List<LLX_LLH1> LLH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.LH1, 0, 10);
		validator.CollectionSize(x => x.LLH1, 0, 100);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
