using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C212")]
public class C212_ItemNumberIdentification : EdifactComponent
{
	[Position(1)]
	public string ItemNumber { get; set; }

	[Position(2)]
	public string ItemTypeIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C212_ItemNumberIdentification>(this);
		validator.Length(x => x.ItemNumber, 1, 35);
		validator.Length(x => x.ItemTypeIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
