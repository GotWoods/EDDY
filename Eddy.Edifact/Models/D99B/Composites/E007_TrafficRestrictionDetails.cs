using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E007")]
public class E007_TrafficRestrictionDetails : EdifactComponent
{
	[Position(1)]
	public string TrafficRestrictionCoded { get; set; }

	[Position(2)]
	public string TrafficRestrictionTypeCoded { get; set; }

	[Position(3)]
	public string TrafficRestrictionTypeQualifier { get; set; }

	[Position(4)]
	public string FreeTextValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E007_TrafficRestrictionDetails>(this);
		validator.Length(x => x.TrafficRestrictionCoded, 1, 3);
		validator.Length(x => x.TrafficRestrictionTypeCoded, 1, 3);
		validator.Length(x => x.TrafficRestrictionTypeQualifier, 1, 3);
		validator.Length(x => x.FreeTextValue, 1, 512);
		return validator.Results;
	}
}
