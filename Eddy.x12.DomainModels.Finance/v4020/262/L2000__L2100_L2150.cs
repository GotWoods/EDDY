using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._262;

public class L2000__L2100_L2150 {
	[SectionPosition(1)] public RET_RealEstateTransaction RealEstateTransaction { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<PTF_PropertyTransactionFinancials> PropertyTransactionFinancials { get; set; } = new();
	[SectionPosition(5)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(6)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(7)] public List<L2000__L2100__L2150_L2151> L2151 {get;set;} = new();
	[SectionPosition(8)] public List<L2000__L2100__L2150_L2152> L2152 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2100_L2150>(this);
		validator.Required(x => x.RealEstateTransaction);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.PropertyTransactionFinancials, 1, 2147483647);
		validator.CollectionSize(x => x.Quantity, 1, 2147483647);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		validator.CollectionSize(x => x.L2151, 1, 2147483647);
		validator.CollectionSize(x => x.L2152, 1, 2147483647);
		foreach (var item in L2151) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2152) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
