using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._304;

public class LLX_LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public QTY_Quantity? Quantity { get; set; }
	[SectionPosition(3)] public N12_EquipmentEnvironment? EquipmentEnvironment { get; set; }
	[SectionPosition(4)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(5)] public W09_EquipmentAndTemperature? EquipmentAndTemperature { get; set; }
	[SectionPosition(6)] public List<LLX__LN7_LL1> LL1 {get;set;} = new();
	[SectionPosition(7)] public L4_Measurement? Measurement { get; set; }
	[SectionPosition(8)] public L7_TariffReference? TariffReference { get; set; }
	[SectionPosition(9)] public X1_ExportLicense? ExportLicense { get; set; }
	[SectionPosition(10)] public X2_ImportLicense? ImportLicense { get; set; }
	[SectionPosition(11)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(12)] public List<LLX__LN7_LH1> LH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 3);
		validator.CollectionSize(x => x.LL1, 0, 20);
		validator.CollectionSize(x => x.LH1, 0, 10);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
