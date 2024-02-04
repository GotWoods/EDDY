using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._223;

public class L4000_L4500 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(3)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(6)] public List<CSD_ConsolidatedShipmentInvoiceData> ConsolidatedShipmentInvoiceData { get; set; } = new();
	[SectionPosition(7)] public List<L4000__L4500_L4520> L4520 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L4000_L4500>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.ConsolidatedShipmentInvoiceData, 0, 20);
		validator.CollectionSize(x => x.L4520, 0, 9999);
		foreach (var item in L4520) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
