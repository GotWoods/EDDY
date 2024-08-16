using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C509")]
public class C509_PriceInformation : EdifactComponent
{
	[Position(1)]
	public string PriceQualifier { get; set; }

	[Position(2)]
	public string Price { get; set; }

	[Position(3)]
	public string PriceTypeCoded { get; set; }

	[Position(4)]
	public string PriceSpecificationCode { get; set; }

	[Position(5)]
	public string UnitPriceBasis { get; set; }

	[Position(6)]
	public string MeasurementUnitCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C509_PriceInformation>(this);
		validator.Required(x=>x.PriceQualifier);
		validator.Length(x => x.PriceQualifier, 1, 3);
		validator.Length(x => x.Price, 1, 15);
		validator.Length(x => x.PriceTypeCoded, 1, 3);
		validator.Length(x => x.PriceSpecificationCode, 1, 3);
		validator.Length(x => x.UnitPriceBasis, 1, 9);
		validator.Length(x => x.MeasurementUnitCode, 1, 3);
		return validator.Results;
	}
}
