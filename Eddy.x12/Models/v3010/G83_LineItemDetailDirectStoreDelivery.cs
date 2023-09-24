using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G83")]
public class G83_LineItemDetailDirectStoreDelivery : EdiX12Segment
{
	[Position(01)]
	public int? DirectStoreDeliverySequenceNumber { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public string UPCConsumerPackageCode { get; set; }

	[Position(05)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(06)]
	public string ProductServiceID { get; set; }

	[Position(07)]
	public string UPCCaseCode { get; set; }

	[Position(08)]
	public decimal? ItemListCost { get; set; }

	[Position(09)]
	public int? Pack { get; set; }

	[Position(10)]
	public string CashRegisterItemDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G83_LineItemDetailDirectStoreDelivery>(this);
		validator.Required(x=>x.DirectStoreDeliverySequenceNumber);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Length(x => x.DirectStoreDeliverySequenceNumber, 1, 4);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.UPCConsumerPackageCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ItemListCost, 1, 9);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.CashRegisterItemDescription, 1, 20);
		return validator.Results;
	}
}
