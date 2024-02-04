using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._310;

public class LLX_LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(3)] public V4_CargoLocationReference? CargoLocationReference { get; set; }
	[SectionPosition(4)] public N12_EquipmentEnvironment? EquipmentEnvironment { get; set; }
	[SectionPosition(5)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(6)] public W09_EquipmentAndTemperature? EquipmentAndTemperature { get; set; }
	[SectionPosition(7)] public List<LLX__LN7_LL1> LL1 {get;set;} = new();
	[SectionPosition(8)] public L7_TariffReference? TariffReference { get; set; }
	[SectionPosition(9)] public X1_ExportLicense? ExportLicense { get; set; }
	[SectionPosition(10)] public X2_ImportLicense? ImportLicense { get; set; }
	[SectionPosition(11)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(12)] public List<LLX__LN7_LH1> LH1 {get;set;} = new();
	[SectionPosition(13)] public List<LLX__LN7_LLH1> LLH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 3);
		validator.CollectionSize(x => x.LL1, 0, 20);
		validator.CollectionSize(x => x.LH1, 0, 10);
		validator.CollectionSize(x => x.LLH1, 0, 100);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
