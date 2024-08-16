using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C080")]
public class C080_PartyName : EdifactComponent
{
	[Position(1)]
	public string PartyName { get; set; }

	[Position(2)]
	public string PartyName2 { get; set; }

	[Position(3)]
	public string PartyName3 { get; set; }

	[Position(4)]
	public string PartyName4 { get; set; }

	[Position(5)]
	public string PartyName5 { get; set; }

	[Position(6)]
	public string PartyNameFormatCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C080_PartyName>(this);
		validator.Required(x=>x.PartyName);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.PartyName2, 1, 35);
		validator.Length(x => x.PartyName3, 1, 35);
		validator.Length(x => x.PartyName4, 1, 35);
		validator.Length(x => x.PartyName5, 1, 35);
		validator.Length(x => x.PartyNameFormatCoded, 1, 3);
		return validator.Results;
	}
}
