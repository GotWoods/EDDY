using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Finance.v5010._811;

public class LHL_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public VEH_VehicleInformation? VehicleInformation { get; set; }
	[SectionPosition(3)] public List<SI_ServiceCharacteristicIdentification> ServiceCharacteristicIdentification { get; set; } = new();
	[SectionPosition(4)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(5)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(6)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(8)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(9)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(10)] public List<LHL__LLX_LQTY> LQTY {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.ServiceCharacteristicIdentification, 0, 8);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 200);
		validator.CollectionSize(x => x.Measurements, 0, 20);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 0, 8);
		validator.CollectionSize(x => x.TaxInformation, 1, 2147483647);
		validator.CollectionSize(x => x.LQTY, 0, 10);
		foreach (var item in LQTY) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
