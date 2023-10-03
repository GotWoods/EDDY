using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7060.Composites;

[Segment("C066")]
public class C066_SellingOrOrderingProductBasisCode : EdiX12Component
{
	[Position(00)]
	public string ProductProcurementBasisCode { get; set; }

	[Position(01)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(02)]
	public string ProductProcurementBasisCode2 { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(04)]
	public string ProductProcurementBasisCode3 { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C066_SellingOrOrderingProductBasisCode>(this);
		validator.Required(x=>x.ProductProcurementBasisCode);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductProcurementBasisCode2, x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductProcurementBasisCode3, x=>x.UnitOrBasisForMeasurementCode3);
		validator.Length(x => x.ProductProcurementBasisCode, 1);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.ProductProcurementBasisCode2, 1);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.ProductProcurementBasisCode3, 1);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		return validator.Results;
	}
}
