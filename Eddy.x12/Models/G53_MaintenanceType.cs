using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G53")]
public class G53_MaintenanceType : EdiX12Segment
{
	[Position(01)]
	public string MaintenanceTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G53_MaintenanceType>(this);
		validator.Required(x=>x.MaintenanceTypeCode);
		validator.Length(x => x.MaintenanceTypeCode, 3);
		return validator.Results;
	}
}
