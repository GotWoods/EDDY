using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("JID")]
public class JID_EquipmentDetail : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(02)]
	public string ProductServiceID { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(05)]
	public string ProductServiceConditionCode { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<JID_EquipmentDetail>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.ARequiresB(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.ProductServiceConditionCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		return validator.Results;
	}
}
