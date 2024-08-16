using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Models.D97B;

[Segment("PRD")]
public class PRD_ProductIdentification : EdifactSegment
{
	[Position(1)]
	public E989_ProductIdentificationDetails ProductIdentificationDetails { get; set; }

	[Position(2)]
	public string PartyName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRD_ProductIdentification>(this);
		validator.Length(x => x.PartyName, 1, 35);
		return validator.Results;
	}
}
