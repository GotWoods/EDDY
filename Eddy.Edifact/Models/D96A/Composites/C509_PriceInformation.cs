using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

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
	public string PriceTypeQualifier { get; set; }

	[Position(5)]
	public string UnitPriceBasis { get; set; }

	[Position(6)]
	public string MeasureUnitQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C509_PriceInformation>(this);
		validator.Required(x=>x.PriceQualifier);
		validator.Length(x => x.PriceQualifier, 1, 3);
		validator.Length(x => x.Price, 1, 15);
		validator.Length(x => x.PriceTypeCoded, 1, 3);
		validator.Length(x => x.PriceTypeQualifier, 1, 3);
		validator.Length(x => x.UnitPriceBasis, 1, 9);
		validator.Length(x => x.MeasureUnitQualifier, 1, 3);
		return validator.Results;
	}
}
