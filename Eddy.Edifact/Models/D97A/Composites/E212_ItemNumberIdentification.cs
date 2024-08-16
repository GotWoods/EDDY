using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E212")]
public class E212_ItemNumberIdentification : EdifactComponent
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
		var validator = new BasicValidator<E212_ItemNumberIdentification>(this);
		validator.Length(x => x.ItemNumber, 1, 35);
		validator.Length(x => x.ItemNumberTypeCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
