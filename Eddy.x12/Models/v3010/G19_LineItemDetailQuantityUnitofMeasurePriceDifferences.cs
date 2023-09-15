using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G19")]
public class G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences : EdiX12Segment
{
	[Position(01)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(02)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(03)]
	public decimal? QuantityDifference { get; set; }

	[Position(04)]
	public string ShipmentOrderStatusCode { get; set; }

	[Position(05)]
	public string PriceReasonCode { get; set; }

	[Position(06)]
	public string TermsExceptionCode { get; set; }

	[Position(07)]
	public string UPCCaseCode { get; set; }

	[Position(08)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(09)]
	public string ProductServiceID { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences>(this);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.QuantityDifference, 1, 9);
		validator.Length(x => x.ShipmentOrderStatusCode, 2);
		validator.Length(x => x.PriceReasonCode, 1);
		validator.Length(x => x.TermsExceptionCode, 2);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		return validator.Results;
	}
}
