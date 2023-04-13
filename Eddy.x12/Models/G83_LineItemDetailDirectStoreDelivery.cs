using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G83")]
public class G83_LineItemDetailDirectStoreDelivery : EdiX12Segment
{
	[Position(01)]
	public int? DirectStoreDeliverySequenceNumber { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

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

	[Position(10)]
	public string CashRegisterItemDescription { get; set; }

	[Position(11)]
	public string ProductServiceIDQualifier2 { get; set; }

	[Position(12)]
	public string ProductServiceID2 { get; set; }

	[Position(13)]
	public int? InnerPack { get; set; }

	[Position(14)]
	public string ProductServiceIDQualifier3 { get; set; }

	[Position(15)]
	public string ProductServiceID3 { get; set; }

	[Position(16)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(17)]
	public decimal? ItemListCost2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G83_LineItemDetailDirectStoreDelivery>(this);
		validator.Required(x=>x.DirectStoreDeliverySequenceNumber);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.AtLeastOneIsRequired(x=>x.UPCEANConsumerPackageCode, x=>x.ProductServiceIDQualifier);
		validator.OnlyOneOf(x=>x.UPCEANConsumerPackageCode, x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.ARequiresB(x=>x.UPCCaseCode, x=>x.Pack);
		validator.OnlyOneOf(x=>x.UPCCaseCode, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier2, x=>x.ProductServiceID2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier3, x=>x.ProductServiceID3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode2, x=>x.ItemListCost2);
		validator.Length(x => x.DirectStoreDeliverySequenceNumber, 1, 4);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.UPCEANConsumerPackageCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ItemListCost, 1, 9);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.CashRegisterItemDescription, 1, 20);
		validator.Length(x => x.ProductServiceIDQualifier2, 2);
		validator.Length(x => x.ProductServiceID2, 1, 80);
		validator.Length(x => x.InnerPack, 1, 6);
		validator.Length(x => x.ProductServiceIDQualifier3, 2);
		validator.Length(x => x.ProductServiceID3, 1, 80);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.ItemListCost2, 1, 9);
		return validator.Results;
	}
}
