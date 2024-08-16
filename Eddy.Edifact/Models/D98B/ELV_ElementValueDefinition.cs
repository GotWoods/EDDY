using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Models.D98B;

[Segment("ELV")]
public class ELV_ElementValueDefinition : EdifactSegment
{
	[Position(1)]
	public string ValueDefinitionQualifier { get; set; }

	[Position(2)]
	public string Value { get; set; }

	[Position(3)]
	public string RequirementDesignatorCoded { get; set; }

	[Position(4)]
	public string MaintenanceOperationCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ELV_ElementValueDefinition>(this);
		validator.Required(x=>x.ValueDefinitionQualifier);
		validator.Length(x => x.ValueDefinitionQualifier, 1, 3);
		validator.Length(x => x.Value, 1, 512);
		validator.Length(x => x.RequirementDesignatorCoded, 1, 3);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		return validator.Results;
	}
}
