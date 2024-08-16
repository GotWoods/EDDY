using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("E212")]
public class E212_ItemNumberIdentification : EdifactComponent
{
	[Position(1)]
	public string ItemIdentifier { get; set; }

	[Position(2)]
	public string ItemTypeIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E212_ItemNumberIdentification>(this);
		validator.Length(x => x.ItemIdentifier, 1, 35);
		validator.Length(x => x.ItemTypeIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
