using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E019")]
public class E019_PromotionDetails : EdifactComponent
{
	[Position(1)]
	public string PartyName { get; set; }

	[Position(2)]
	public string YesOrNoIndicatorCode { get; set; }

	[Position(3)]
	public string ReferenceIdentifier { get; set; }

	[Position(4)]
	public string FreeTextValue { get; set; }

	[Position(5)]
	public string FreeTextValue2 { get; set; }

	[Position(6)]
	public string FreeTextValue3 { get; set; }

	[Position(7)]
	public string FreeTextValue4 { get; set; }

	[Position(8)]
	public string FreeTextValue5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E019_PromotionDetails>(this);
		validator.Required(x=>x.PartyName);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.YesOrNoIndicatorCode, 1, 3);
		validator.Length(x => x.ReferenceIdentifier, 1, 35);
		validator.Length(x => x.FreeTextValue, 1, 512);
		validator.Length(x => x.FreeTextValue2, 1, 512);
		validator.Length(x => x.FreeTextValue3, 1, 512);
		validator.Length(x => x.FreeTextValue4, 1, 512);
		validator.Length(x => x.FreeTextValue5, 1, 512);
		return validator.Results;
	}
}
