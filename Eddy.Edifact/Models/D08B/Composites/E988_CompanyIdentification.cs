using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D08B.Composites;

[Segment("E988")]
public class E988_CompanyIdentification : EdifactComponent
{
	[Position(1)]
	public string PartyName { get; set; }

	[Position(2)]
	public string PartyName2 { get; set; }

	[Position(3)]
	public string PartyName3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E988_CompanyIdentification>(this);
		validator.Required(x=>x.PartyName);
		validator.Length(x => x.PartyName, 1, 70);
		validator.Length(x => x.PartyName2, 1, 70);
		validator.Length(x => x.PartyName3, 1, 70);
		return validator.Results;
	}
}
