using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G51")]
public class G51_FreeGoods : EdiX12Segment
{
	[Position(01)]
	public int? QuantityFree { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public int? QuantityMustPurchase { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(05)]
	public string UPCCaseCode { get; set; }

	[Position(06)]
	public string UPCEANConsumerPackageCode { get; set; }

	[Position(07)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(08)]
	public string ProductServiceID { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G51_FreeGoods>(this);
		validator.Required(x=>x.QuantityFree);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.QuantityMustPurchase);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.Length(x => x.QuantityFree, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.QuantityMustPurchase, 1, 9);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.UPCEANConsumerPackageCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 40);
		return validator.Results;
	}
}
