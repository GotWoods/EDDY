using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._880;

public class L0300 {
	[SectionPosition(1)] public G17_ItemDetailInvoice ItemDetailInvoice { get; set; } = new();
	[SectionPosition(2)] public List<G69_LineItemDetailDescription> LineItemDetailDescription { get; set; } = new();
	[SectionPosition(3)] public List<G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences> LineItemDetailQuantityUnitOfMeasurePriceDifferences { get; set; } = new();
	[SectionPosition(4)] public G20_ItemPackingDetail? ItemPackingDetail { get; set; }
	[SectionPosition(5)] public List<N9_ReferenceIdentification> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<G23_TermsOfSale> TermsOfSale { get; set; } = new();
	[SectionPosition(7)] public G25_FOBInformation? FOBInformation { get; set; }
	[SectionPosition(8)] public List<L0300_L0310> L0310 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300>(this);
		validator.Required(x => x.ItemDetailInvoice);
		validator.CollectionSize(x => x.LineItemDetailDescription, 0, 5);
		validator.CollectionSize(x => x.LineItemDetailQuantityUnitOfMeasurePriceDifferences, 0, 10);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 5);
		validator.CollectionSize(x => x.TermsOfSale, 0, 20);
		validator.CollectionSize(x => x.L0310, 0, 100);
		foreach (var item in L0310) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
