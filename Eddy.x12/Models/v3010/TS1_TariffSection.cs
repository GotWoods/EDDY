using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TS1")]
public class TS1_TariffSection : EdiX12Segment
{
	[Position(01)]
	public string FreeFormDescription { get; set; }

	[Position(02)]
	public string WeightUnitQualifier { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public string VolumeUnitQualifier { get; set; }

	[Position(05)]
	public decimal? Quantity2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TS1_TariffSection>(this);
		validator.Required(x=>x.FreeFormDescription);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.WeightUnitQualifier, 1);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.VolumeUnitQualifier, 1);
		validator.Length(x => x.Quantity2, 1, 10);
		return validator.Results;
	}
}
