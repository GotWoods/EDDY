using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;
using Eddy.x12.DomainModels.Finance.v6040._151;

namespace Eddy.x12.DomainModels.Finance.v6040;

public class Edi151_ElectronicFilingOfTaxReturnDataAcknowledgment {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BTA_BeginningTaxAcknowledgment BeginningTaxAcknowledgment { get; set; } = new();
	[SectionPosition(3)] public BTI_BeginningTaxInformation BeginningTaxInformation { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(7)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(8)] public List<LPBI> LPBI {get;set;} = new();

	//Details
	[SectionPosition(9)] public List<LTFS> LTFS {get;set;} = new();
	[SectionPosition(10)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi151_ElectronicFilingOfTaxReturnDataAcknowledgment>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningTaxAcknowledgment);
		validator.Required(x => x.BeginningTaxInformation);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 10);
		validator.CollectionSize(x => x.QuantityInformation, 0, 10);
		

		validator.CollectionSize(x => x.LPBI, 0, 1000);
		foreach (var item in LPBI) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LTFS, 0, 100000);
		foreach (var item in LTFS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
