using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G51")]
public class G51_FreeGoods : EdiX12Segment
{
	[Position(01)]
	public int? QuantityFree { get; set; }

	[Position(02)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(03)]
	public int? QuantityMustPurchase { get; set; }

	[Position(04)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(05)]
	public string UPCCaseCode { get; set; }

	[Position(06)]
	public string UPCConsumerPackageCode { get; set; }

	[Position(07)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(08)]
	public string ProductServiceID { get; set; }

	[Position(09)]
	public string UnitOfMeasurementCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G51_FreeGoods>(this);
		validator.Required(x=>x.QuantityFree);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Required(x=>x.QuantityMustPurchase);
		validator.Required(x=>x.UnitOfMeasurementCode2);
		validator.Length(x => x.QuantityFree, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.QuantityMustPurchase, 1, 9);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.UPCConsumerPackageCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.UnitOfMeasurementCode3, 2);
		return validator.Results;
	}
}
