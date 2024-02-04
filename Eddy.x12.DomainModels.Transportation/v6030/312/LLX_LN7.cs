using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Transportation.v6030._312;

public class LLX_LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(3)] public N12_EquipmentEnvironment? EquipmentEnvironment { get; set; }
	[SectionPosition(4)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(5)] public W09_EquipmentAndTemperature? EquipmentAndTemperature { get; set; }
	[SectionPosition(6)] public L4_Measurement? Measurement { get; set; }
	[SectionPosition(7)] public List<LLX__LN7_LH1> LH1 {get;set;} = new();
	[SectionPosition(8)] public List<LLX__LN7_LLH1> LLH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.LH1, 0, 2);
		validator.CollectionSize(x => x.LLH1, 0, 100);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
