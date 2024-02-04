using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._215;

public class L0200_L0260 {
	[SectionPosition(1)] public AT6_InternationalManifestInformation InternationalManifestInformation { get; set; } = new();
	[SectionPosition(2)] public MS5_ShipmentRatesAndCharges? ShipmentRatesAndCharges { get; set; }
	[SectionPosition(3)] public IT1_BaselineItemDataInvoice? BaselineItemDataInvoice { get; set; }
	[SectionPosition(4)] public List<CGS_Charge> Charge { get; set; } = new();
	[SectionPosition(5)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(6)] public L11_BusinessInstructions? BusinessInstructionsAndReferenceNumber { get; set; }
	[SectionPosition(7)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(8)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(9)] public MS4_ShipmentOrPackageDimensions? ShipmentOrPackageDimensions { get; set; }
	[SectionPosition(10)] public L5_DescriptionMarksAndNumbers? DescriptionMarksAndNumbers { get; set; }
	[SectionPosition(11)] public List<L0200__L0260_L0280> L0280 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0260>(this);
		validator.Required(x => x.InternationalManifestInformation);
		validator.CollectionSize(x => x.Charge, 0, 10);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 1000);
		validator.CollectionSize(x => x.TaxInformation, 0, 10);
		validator.CollectionSize(x => x.L0280, 0, 999999);
		foreach (var item in L0280) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
