using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("UPI")]
public class UPI_UniversalProductIdentification : EdiX12Segment
{
	[Position(01)]
	public string AssignedIdentification { get; set; }

	[Position(02)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(03)]
	public string ProductServiceID { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(05)]
	public string DisplayTypeCode { get; set; }

	[Position(06)]
	public C065_ProductUnitIndicator ProductUnitIndicator { get; set; }

	[Position(07)]
	public string StockIndicatorCode { get; set; }

	[Position(08)]
	public string ActionCode { get; set; }

	[Position(09)]
	public string ProductionType { get; set; }

	[Position(10)]
	public decimal? Quantity { get; set; }

	[Position(11)]
	public string LifeCycleStatusCode { get; set; }

	[Position(12)]
	public C066_SellingOrOrderingProductBasisCode SellingOrOrderingProductBasisCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UPI_UniversalProductIdentification>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Length(x => x.AssignedIdentification, 1, 20);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.DisplayTypeCode, 3);
		validator.Length(x => x.StockIndicatorCode, 1);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.ProductionType, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.LifeCycleStatusCode, 1);
		return validator.Results;
	}
}
