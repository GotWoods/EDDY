using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("ASI")]
public class ASI_ActionOrStatusIndicator : EdiX12Segment
{
	[Position(01)]
	public string ActionCode { get; set; }

	[Position(02)]
	public string MaintenanceTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ASI_ActionOrStatusIndicator>(this);
		validator.Required(x=>x.ActionCode);
		validator.Required(x=>x.MaintenanceTypeCode);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		return validator.Results;
	}
}
