using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C273")]
public class C273_ItemDescription : EdifactComponent
{
	[Position(1)]
	public string ItemDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ItemDescription { get; set; }

	[Position(5)]
	public string ItemDescription2 { get; set; }

	[Position(6)]
	public string LanguageNameCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C273_ItemDescription>(this);
		validator.Length(x => x.ItemDescriptionCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ItemDescription, 1, 256);
		validator.Length(x => x.ItemDescription2, 1, 256);
		validator.Length(x => x.LanguageNameCode, 1, 3);
		return validator.Results;
	}
}
