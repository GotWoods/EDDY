using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D08B.Composites;

[Segment("E080")]
public class E080_PartyName : EdifactComponent
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
	public string PartyNameFormatCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E080_PartyName>(this);
		validator.Required(x=>x.PartyName);
		validator.Length(x => x.PartyName, 1, 70);
		validator.Length(x => x.PartyName2, 1, 70);
		validator.Length(x => x.PartyName3, 1, 70);
		validator.Length(x => x.PartyName4, 1, 70);
		validator.Length(x => x.PartyName5, 1, 70);
		validator.Length(x => x.PartyNameFormatCode, 1, 3);
		return validator.Results;
	}
}