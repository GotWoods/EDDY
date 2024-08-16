using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("C234")]
public class C234_UNDGInformation : EdifactComponent
{
	[Position(1)]
	public string UnitedNationsDangerousGoodsUNDGIdentifier { get; set; }

	[Position(2)]
	public string DangerousGoodsFlashpointDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C234_UNDGInformation>(this);
		validator.Length(x => x.UnitedNationsDangerousGoodsUNDGIdentifier, 4);
		validator.Length(x => x.DangerousGoodsFlashpointDescription, 1, 8);
		return validator.Results;
	}
}
