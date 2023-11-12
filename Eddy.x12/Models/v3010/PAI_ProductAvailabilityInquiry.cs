using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("PAI")]
public class PAI_ProductAvailabilityInquiry : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public string PriceQualifier { get; set; }

	[Position(05)]
	public decimal? UnitPrice { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PAI_ProductAvailabilityInquiry>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.PriceQualifier, 3);
		validator.Length(x => x.UnitPrice, 1, 14);
		return validator.Results;
	}
}
