using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G2")]
public class G2_BeyondRouting : EdiX12Segment
{
	[Position(01)]
	public string SpecialIndicatorCode { get; set; }

	[Position(02)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G2_BeyondRouting>(this);
		validator.Required(x=>x.SpecialIndicatorCode);
		validator.Length(x => x.SpecialIndicatorCode, 1);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
