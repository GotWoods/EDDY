using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D03A.Composites;

[Segment("C509")]
public class C509_PriceInformation : EdifactComponent
{
	[Position(1)]
	public string PriceCodeQualifier { get; set; }

	[Position(2)]
	public string PriceAmount { get; set; }

	[Position(3)]
	public string PriceTypeCode { get; set; }

	[Position(4)]
	public string PriceSpecificationCode { get; set; }

	[Position(5)]
	public string UnitPriceBasisQuantity { get; set; }

	[Position(6)]
	public string MeasurementUnitCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C509_PriceInformation>(this);
		validator.Required(x=>x.PriceCodeQualifier);
		validator.Length(x => x.PriceCodeQualifier, 1, 3);
		validator.Length(x => x.PriceAmount, 1, 15);
		validator.Length(x => x.PriceTypeCode, 1, 3);
		validator.Length(x => x.PriceSpecificationCode, 1, 3);
		validator.Length(x => x.UnitPriceBasisQuantity, 1, 9);
		validator.Length(x => x.MeasurementUnitCode, 1, 8);
		return validator.Results;
	}
}
