using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Models.D08B;

[Segment("MAP")]
public class MAP_MessageApplicationProductInformation : EdifactSegment
{
	[Position(1)]
	public E022_InstructionInformation InstructionInformation { get; set; }

	[Position(2)]
	public string PartyName { get; set; }

	[Position(3)]
	public E031_MessageApplicationProductSpecification MessageApplicationProductSpecification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MAP_MessageApplicationProductInformation>(this);
		validator.Length(x => x.PartyName, 1, 70);
		return validator.Results;
	}
}
