using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C212")]
public class C212_ItemNumberIdentification : EdifactComponent
{
	[Position(1)]
	public string ItemNumber { get; set; }

	[Position(2)]
	public string ItemNumberTypeCoded { get; set; }

	[Position(3)]
	public string CodeListQualifier { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C212_ItemNumberIdentification>(this);
		validator.Length(x => x.ItemNumber, 1, 35);
		validator.Length(x => x.ItemNumberTypeCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
