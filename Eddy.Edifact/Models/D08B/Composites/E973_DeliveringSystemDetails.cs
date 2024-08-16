using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D08B.Composites;

[Segment("E973")]
public class E973_DeliveringSystemDetails : EdifactComponent
{
	[Position(1)]
	public string PartyName { get; set; }

	[Position(2)]
	public string LocationIdentifier { get; set; }

	[Position(3)]
	public string LocationName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E973_DeliveringSystemDetails>(this);
		validator.Length(x => x.PartyName, 1, 70);
		validator.Length(x => x.LocationIdentifier, 1, 35);
		validator.Length(x => x.LocationName, 1, 256);
		return validator.Results;
	}
}
