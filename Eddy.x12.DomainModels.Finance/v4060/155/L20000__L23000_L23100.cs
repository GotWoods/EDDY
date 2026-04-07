using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Finance.v4060._155;

public class L20000__L23000_L23100 {
	[SectionPosition(1)] public INQ_CreditInquiryDetails CreditInquiryDetails { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(3)] public C3_Currency? CurrencyIdentifier { get; set; }
	[SectionPosition(4)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(5)] public List<PYT_HistoricalPaymentTerms> HistoricalPaymentTerms { get; set; } = new();
	[SectionPosition(6)] public List<PYM_PaymentMannerAndPercentage> PaymentMannerAndPercentage { get; set; } = new();
	[SectionPosition(7)] public List<AWD_AmountWithDescription> AmountWithDescription { get; set; } = new();
	[SectionPosition(8)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(9)] public List<ACD_AccountDescription> AccountDescription { get; set; } = new();
	[SectionPosition(10)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(11)] public List<SPR_SupplierRating> SupplierRating { get; set; } = new();
	[SectionPosition(12)] public List<ASO_AssetOwnership> AssetOwnership { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000__L23000_L23100>(this);
		validator.Required(x => x.CreditInquiryDetails);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		validator.CollectionSize(x => x.HistoricalPaymentTerms, 1, 2147483647);
		validator.CollectionSize(x => x.PaymentMannerAndPercentage, 1, 2147483647);
		validator.CollectionSize(x => x.AmountWithDescription, 1, 2147483647);
		validator.CollectionSize(x => x.AccountDescription, 1, 2147483647);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		validator.CollectionSize(x => x.SupplierRating, 1, 2147483647);
		validator.CollectionSize(x => x.AssetOwnership, 1, 2147483647);
		return validator.Results;
	}
}
