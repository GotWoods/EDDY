using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Models.D98B;

[Segment("DFN")]
public class DFN_DefinitionFunction : EdifactSegment
{
	[Position(1)]
	public string DefinitionFunctionCoded { get; set; }

	[Position(2)]
	public string DefinitionExtentCoded { get; set; }

	[Position(3)]
	public string DefinitionIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DFN_DefinitionFunction>(this);
		validator.Required(x=>x.DefinitionFunctionCoded);
		validator.Length(x => x.DefinitionFunctionCoded, 1, 3);
		validator.Length(x => x.DefinitionExtentCoded, 1, 3);
		validator.Length(x => x.DefinitionIdentification, 1, 35);
		return validator.Results;
	}
}
