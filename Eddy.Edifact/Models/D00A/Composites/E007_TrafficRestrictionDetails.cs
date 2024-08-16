using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E007")]
public class E007_TrafficRestrictionDetails : EdifactComponent
{
	[Position(1)]
	public string TrafficRestrictionCode { get; set; }

	[Position(2)]
	public string TrafficRestrictionApplicationCode { get; set; }

	[Position(3)]
	public string TrafficRestrictionTypeCodeQualifier { get; set; }

	[Position(4)]
	public string FreeTextValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E007_TrafficRestrictionDetails>(this);
		validator.Length(x => x.TrafficRestrictionCode, 1, 3);
		validator.Length(x => x.TrafficRestrictionApplicationCode, 1, 3);
		validator.Length(x => x.TrafficRestrictionTypeCodeQualifier, 1, 3);
		validator.Length(x => x.FreeTextValue, 1, 512);
		return validator.Results;
	}
}
