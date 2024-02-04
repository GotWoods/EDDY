using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._304;

public class LLX_LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public QTY_Quantity? Quantity { get; set; }
	[SectionPosition(3)] public L4_Measurement? Measurement { get; set; }
	[SectionPosition(4)] public N12_EquipmentEnvironment? EquipmentEnvironment { get; set; }
	[SectionPosition(5)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	[SectionPosition(6)] public List<M7A_SealNumberReplacement> SealNumberReplacement { get; set; } = new();
	[SectionPosition(7)] public W09_EquipmentAndTemperature? EquipmentAndTemperature { get; set; }
	[SectionPosition(8)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(9)] public List<LLX__LN7_LL1> LL1 {get;set;} = new();
	[SectionPosition(10)] public L7_TariffReference? TariffReference { get; set; }
	[SectionPosition(11)] public List<X1_ExportLicense> ExportLicense { get; set; } = new();
	[SectionPosition(12)] public List<X2_ImportLicense> ImportLicense { get; set; } = new();
	[SectionPosition(13)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(14)] public List<LLX__LN7_LH1> LH1 {get;set;} = new();
	[SectionPosition(15)] public List<LLX__LN7_LLH1> LLH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.SealNumbers, 0, 5);
		validator.CollectionSize(x => x.SealNumberReplacement, 0, 100);
		validator.CollectionSize(x => x.HazardousCertification, 0, 6);
		validator.CollectionSize(x => x.ExportLicense, 0, 25);
		validator.CollectionSize(x => x.ImportLicense, 0, 5);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 100);
		validator.CollectionSize(x => x.LL1, 0, 20);
		validator.CollectionSize(x => x.LH1, 0, 10);
		validator.CollectionSize(x => x.LLH1, 0, 100);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
