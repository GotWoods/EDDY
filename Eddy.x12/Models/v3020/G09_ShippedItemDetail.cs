using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("G09")]
public class G09_ShippedItemDetail : EdiX12Segment
{
	[Position(01)]
	public decimal? QuantityReceived { get; set; }

	[Position(02)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(03)]
	public string ReceivingConditionCode { get; set; }

	[Position(04)]
	public string UPCCaseCode { get; set; }

	[Position(05)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(06)]
	public string ProductServiceID { get; set; }

	[Position(07)]
	public decimal? NumberOfUnitsShipped { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G09_ShippedItemDetail>(this);
		validator.Required(x=>x.QuantityReceived);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Required(x=>x.ReceivingConditionCode);
		validator.AtLeastOneIsRequired(x=>x.UPCCaseCode, x=>x.ProductServiceIDQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ProductServiceIDQualifier, x=>x.ProductServiceID);
		validator.Length(x => x.QuantityReceived, 1, 7);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.ReceivingConditionCode, 2);
		validator.Length(x => x.UPCCaseCode, 12);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		return validator.Results;
	}
}
