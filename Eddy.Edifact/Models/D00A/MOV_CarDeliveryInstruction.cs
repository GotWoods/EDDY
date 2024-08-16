using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("MOV")]
public class MOV_CarDeliveryInstruction : EdifactSegment
{
	[Position(1)]
	public E995_MovementDetails MovementDetails { get; set; }

	[Position(2)]
	public string UnitsQuantity { get; set; }

	[Position(3)]
	public string LanguageNameCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MOV_CarDeliveryInstruction>(this);
		validator.Length(x => x.UnitsQuantity, 1, 15);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		return validator.Results;
	}
}
