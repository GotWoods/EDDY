using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("CDV")]
public class CDV_CodeValueDefinition : EdifactSegment
{
	[Position(1)]
	public string CodeValue { get; set; }

	[Position(2)]
	public string CodeName { get; set; }

	[Position(3)]
	public string MaintenanceOperationCode { get; set; }

	[Position(4)]
	public string CodeValueSourceCode { get; set; }

	[Position(5)]
	public string RequirementDesignatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CDV_CodeValueDefinition>(this);
		validator.Required(x=>x.CodeValue);
		validator.Length(x => x.CodeValue, 1, 35);
		validator.Length(x => x.CodeName, 1, 70);
		validator.Length(x => x.MaintenanceOperationCode, 1, 3);
		validator.Length(x => x.CodeValueSourceCode, 1, 3);
		validator.Length(x => x.RequirementDesignatorCode, 1, 3);
		return validator.Results;
	}
}