using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._304;

public class LL3 {
	[SectionPosition(1)] public L3_TotalWeightAndCharges TotalWeightAndCharges { get; set; } = new();
	[SectionPosition(2)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(4)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(5)] public List<SUP_SupplementaryInformation> SupplementaryInformation { get; set; } = new();
	[SectionPosition(6)] public List<LL3_LL1> LL1 {get;set;} = new();
	[SectionPosition(7)] public List<LL3_LTDS> LTDS {get;set;} = new();
	[SectionPosition(8)] public List<LL3_LSAC> LSAC {get;set;} = new();
	[SectionPosition(9)] public List<LL3_LL9> LL9 {get;set;} = new();
	[SectionPosition(10)] public List<ISS_InvoiceShipmentSummary> InvoiceShipmentSummary { get; set; } = new();
	[SectionPosition(11)] public List<V9_EventDetail> EventDetail { get; set; } = new();
	[SectionPosition(12)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(13)] public List<L11_BusinessInstructions> BusinessInstructions { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LL3>(this);
		validator.Required(x => x.TotalWeightAndCharges);
		validator.CollectionSize(x => x.Measurements, 0, 5);
		validator.CollectionSize(x => x.Paperwork, 0, 50);
		validator.CollectionSize(x => x.SupplementaryInformation, 0, 999);
		validator.CollectionSize(x => x.InvoiceShipmentSummary, 0, 5);
		validator.CollectionSize(x => x.EventDetail, 0, 10);
		validator.CollectionSize(x => x.Remarks, 0, 999);
		validator.CollectionSize(x => x.BusinessInstructions, 0, 24);
		validator.CollectionSize(x => x.LL1, 0, 20);
		validator.CollectionSize(x => x.LSAC, 0, 10);
		validator.CollectionSize(x => x.LL9, 0, 10);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTDS) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSAC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LL9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
