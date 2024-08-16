using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C234")]
public class C234_UNDGInformation : EdifactComponent
{
	[Position(1)]
	public string UnitedNationsDangerousGoodsUNDGIdentifier { get; set; }

	[Position(2)]
	public string DangerousGoodsFlashpointValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C234_UNDGInformation>(this);
		validator.Length(x => x.UnitedNationsDangerousGoodsUNDGIdentifier, 4);
		validator.Length(x => x.DangerousGoodsFlashpointValue, 1, 8);
		return validator.Results;
	}
}
