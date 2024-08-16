using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

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
		validator.Required(x=>x.PartyName2);
		validator.Required(x=>x.PartyName3);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.PartyName2, 1, 35);
		validator.Length(x => x.PartyName3, 1, 35);
		return validator.Results;
	}
}
