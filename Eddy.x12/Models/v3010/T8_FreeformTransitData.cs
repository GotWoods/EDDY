using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("T8")]
public class T8_FreeFormTransitData : EdiX12Segment
{
	[Position(01)]
	public int? AssignedNumber { get; set; }

	[Position(02)]
	public string FreeFormTransitData { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<T8_FreeFormTransitData>(this);
		validator.Required(x=>x.AssignedNumber);
		validator.Required(x=>x.FreeFormTransitData);
		validator.Length(x => x.AssignedNumber, 1, 6);
		validator.Length(x => x.FreeFormTransitData, 1, 80);
		return validator.Results;
	}
}
