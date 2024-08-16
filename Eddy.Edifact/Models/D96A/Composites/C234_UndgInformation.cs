using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C234")]
public class C234_UndgInformation : EdifactComponent
{
	[Position(1)]
	public string UNDGNumber { get; set; }

	[Position(2)]
	public string DangerousGoodsFlashpoint { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C234_UndgInformation>(this);
		validator.Length(x => x.UNDGNumber, 4);
		validator.Length(x => x.DangerousGoodsFlashpoint, 1, 8);
		return validator.Results;
	}
}
