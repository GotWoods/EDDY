using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("G89")]
public class G89_LineItemDetailAdjustment : EdiX12Segment
{
	[Position(01)]
	public int? DirectStoreDeliverySequenceNumber { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public string UPCEANConsumerPackageCode { get; set; }

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G89_LineItemDetailAdjustment>(this);
		validator.Required(x=>x.DirectStoreDeliverySequenceNumber);
		validator.Length(x => x.DirectStoreDeliverySequenceNumber, 1, 4);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.UPCEANConsumerPackageCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ItemListCost, 1, 9);
		validator.Length(x => x.Pack, 1, 6);
		return validator.Results;
	}
}
