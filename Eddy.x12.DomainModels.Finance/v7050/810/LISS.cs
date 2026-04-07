using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Finance.v7050._810;

public class LISS {
	[SectionPosition(1)] public ISS_InvoiceShipmentSummary InvoiceShipmentSummary { get; set; } = new();
	[SectionPosition(2)] public PID_ProductItemDescription? ProductItemDescription { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LISS>(this);
		validator.Required(x => x.InvoiceShipmentSummary);
		return validator.Results;
	}
}
