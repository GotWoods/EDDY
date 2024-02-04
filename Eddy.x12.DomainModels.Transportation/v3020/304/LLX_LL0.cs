using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._304;

public class LLX_LL0 {
	[SectionPosition(1)] public L0_LineItemQuantityAndWeight LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(2)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(3)] public List<L12_AlternateLadingDescription> AlternateLadingDescription { get; set; } = new();
	[SectionPosition(4)] public List<LLX__LL0_LL1> LL1 {get;set;} = new();
	[SectionPosition(5)] public L4_Measurement? Measurement { get; set; }
	[SectionPosition(6)] public L7_TariffReference? TariffReference { get; set; }
	[SectionPosition(7)] public X1_ExportLicense? ExportLicense { get; set; }
	[SectionPosition(8)] public X2_ImportLicense? ImportLicense { get; set; }
	[SectionPosition(9)] public List<C8_CertificationsAndClauses> CertificationsAndClauses { get; set; } = new();
	[SectionPosition(10)] public List<LLX__LL0_LH1> LH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LL0>(this);
		validator.Required(x => x.LineItemQuantityAndWeight);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 999);
		validator.CollectionSize(x => x.AlternateLadingDescription, 0, 20);
		validator.CollectionSize(x => x.CertificationsAndClauses, 0, 10);
		validator.CollectionSize(x => x.LL1, 0, 20);
		validator.CollectionSize(x => x.LH1, 0, 10);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
