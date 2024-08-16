using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Models.D98B;

[Segment("CDV")]
public class CDV_CodeValueDefinition : EdifactSegment
{
	[Position(1)]
	public string CodeValue { get; set; }

	[Position(2)]
	public string CodeName { get; set; }

	[Position(3)]
	public string MaintenanceOperationCoded { get; set; }

	[Position(4)]
	public string CodeValueSourceCoded { get; set; }

	[Position(5)]
	public string RequirementDesignatorCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CDV_CodeValueDefinition>(this);
		validator.Required(x=>x.CodeValue);
		validator.Length(x => x.CodeValue, 1, 35);
		validator.Length(x => x.CodeName, 1, 70);
		validator.Length(x => x.MaintenanceOperationCoded, 1, 3);
		validator.Length(x => x.CodeValueSourceCoded, 1, 3);
		validator.Length(x => x.RequirementDesignatorCoded, 1, 3);
		return validator.Results;
	}
}
