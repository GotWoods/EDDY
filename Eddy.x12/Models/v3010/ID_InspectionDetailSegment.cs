using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("ID")]
public class ID_InspectionDetailSegment : EdiX12Segment
{
	[Position(01)]
	public string DamageAreaCode { get; set; }

	[Position(02)]
	public string DamageTypeCode { get; set; }

	[Position(03)]
	public string DamageSeverityCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ID_InspectionDetailSegment>(this);
		validator.Required(x=>x.DamageAreaCode);
		validator.Required(x=>x.DamageTypeCode);
		validator.Required(x=>x.DamageSeverityCode);
		validator.Length(x => x.DamageAreaCode, 2);
		validator.Length(x => x.DamageTypeCode, 2);
		validator.Length(x => x.DamageSeverityCode, 1);
		return validator.Results;
	}
}
