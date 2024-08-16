using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C779")]
public class C779_ArrayStructureIdentification : EdifactComponent
{
	[Position(1)]
	public string ArrayCellStructureIdentifier { get; set; }

	[Position(2)]
	public string ObjectIdentificationCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C779_ArrayStructureIdentification>(this);
		validator.Required(x=>x.ArrayCellStructureIdentifier);
		validator.Length(x => x.ArrayCellStructureIdentifier, 1, 35);
		validator.Length(x => x.ObjectIdentificationCodeQualifier, 1, 3);
		return validator.Results;
	}
}
