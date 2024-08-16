using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("DFN")]
public class DFN_DefinitionFunction : EdifactSegment
{
	[Position(1)]
	public string DefinitionFunctionCode { get; set; }

	[Position(2)]
	public string DefinitionExtentCode { get; set; }

	[Position(3)]
	public string DefinitionIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DFN_DefinitionFunction>(this);
		validator.Required(x=>x.DefinitionFunctionCode);
		validator.Length(x => x.DefinitionFunctionCode, 1, 3);
		validator.Length(x => x.DefinitionExtentCode, 1, 3);
		validator.Length(x => x.DefinitionIdentifier, 1, 35);
		return validator.Results;
	}
}
