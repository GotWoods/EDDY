using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("ELV")]
public class ELV_ElementValueDefinition : EdifactSegment
{
	[Position(1)]
	public string ValueDefinitionCodeQualifier { get; set; }

	[Position(2)]
	public string ProcessStageValue { get; set; }

	[Position(3)]
	public string RequirementDesignatorCode { get; set; }

	[Position(4)]
	public string MaintenanceOperationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ELV_ElementValueDefinition>(this);
		validator.Required(x=>x.ValueDefinitionCodeQualifier);
		validator.Length(x => x.ValueDefinitionCodeQualifier, 1, 3);
		validator.Length(x => x.ProcessStageValue, 1, 512);
		validator.Length(x => x.RequirementDesignatorCode, 1, 3);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		return validator.Results;
	}
}
