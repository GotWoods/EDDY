using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("R2B")]
public class R2B_JunctionsAndProportions : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string Rule260JunctionCode { get; set; }

	[Position(03)]
	public string Amount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<R2B_JunctionsAndProportions>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Rule260JunctionCode, 1, 5);
		validator.Length(x => x.Amount, 1, 15);
		return validator.Results;
	}
}
