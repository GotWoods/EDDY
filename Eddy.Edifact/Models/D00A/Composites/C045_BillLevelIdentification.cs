using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C045")]
public class C045_BillLevelIdentification : EdifactComponent
{
	[Position(1)]
	public string LevelOneIdentifier { get; set; }

	[Position(2)]
	public string LevelTwoIdentifier { get; set; }

	[Position(3)]
	public string LevelThreeIdentifier { get; set; }

	[Position(4)]
	public string LevelFourIdentifier { get; set; }

	[Position(5)]
	public string LevelFiveIdentifier { get; set; }

	[Position(6)]
	public string LevelSixIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C045_BillLevelIdentification>(this);
		validator.Length(x => x.LevelOneIdentifier, 1, 17);
		validator.Length(x => x.LevelTwoIdentifier, 1, 17);
		validator.Length(x => x.LevelThreeIdentifier, 1, 17);
		validator.Length(x => x.LevelFourIdentifier, 1, 17);
		validator.Length(x => x.LevelFiveIdentifier, 1, 17);
		validator.Length(x => x.LevelSixIdentifier, 1, 17);
		return validator.Results;
	}
}
