using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C273")]
public class C273_ItemDescription : EdifactComponent
{
	[Position(1)]
	public string ItemDescriptionIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string ItemDescription { get; set; }

	[Position(5)]
	public string ItemDescription2 { get; set; }

	[Position(6)]
	public string LanguageCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C273_ItemDescription>(this);
		validator.Length(x => x.ItemDescriptionIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.ItemDescription, 1, 35);
		validator.Length(x => x.ItemDescription2, 1, 35);
		validator.Length(x => x.LanguageCoded, 1, 3);
		return validator.Results;
	}
}
