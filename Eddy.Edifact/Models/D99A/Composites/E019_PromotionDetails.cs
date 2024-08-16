using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99A.Composites;

[Segment("E019")]
public class E019_PromotionDetails : EdifactComponent
{
	[Position(1)]
	public string PartyName { get; set; }

	[Position(2)]
	public string YesNoIndicatorCoded { get; set; }

	[Position(3)]
	public string ReferenceNumber { get; set; }

	[Position(4)]
	public string FreeText { get; set; }

	[Position(5)]
	public string FreeText2 { get; set; }

	[Position(6)]
	public string FreeText3 { get; set; }

	[Position(7)]
	public string FreeText4 { get; set; }

	[Position(8)]
	public string FreeText5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E019_PromotionDetails>(this);
		validator.Required(x=>x.PartyName);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.YesNoIndicatorCoded, 1, 3);
		validator.Length(x => x.ReferenceNumber, 1, 35);
		validator.Length(x => x.FreeText, 1, 70);
		validator.Length(x => x.FreeText2, 1, 70);
		validator.Length(x => x.FreeText3, 1, 70);
		validator.Length(x => x.FreeText4, 1, 70);
		validator.Length(x => x.FreeText5, 1, 70);
		return validator.Results;
	}
}
