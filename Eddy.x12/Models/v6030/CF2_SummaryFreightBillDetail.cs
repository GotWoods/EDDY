using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("CF2")]
public class CF2_SummaryFreightBillDetail : EdiX12Segment
{
	[Position(01)]
	public string InvoiceNumber { get; set; }

	[Position(02)]
	public string NetAmountDue { get; set; }

	[Position(03)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(04)]
	public string ShipmentMethodOfPaymentCode { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string Date2 { get; set; }

	[Position(07)]
	public string WeightQualifier { get; set; }

	[Position(08)]
	public string WeightUnitCode { get; set; }

	[Position(09)]
	public decimal? Weight { get; set; }

	[Position(10)]
	public string TransactionTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CF2_SummaryFreightBillDetail>(this);
		validator.Required(x=>x.InvoiceNumber);
		validator.Required(x=>x.NetAmountDue);
		validator.ARequiresB(x=>x.WeightQualifier, x=>x.Weight);
		validator.ARequiresB(x=>x.WeightUnitCode, x=>x.Weight);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.Weight, x=>x.WeightQualifier, x=>x.WeightUnitCode);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.NetAmountDue, 1, 15);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.TransactionTypeCode, 2);
		return validator.Results;
	}
}
