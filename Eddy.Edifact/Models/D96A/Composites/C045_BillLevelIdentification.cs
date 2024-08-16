using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C045")]
public class C045_BillLevelIdentification : EdifactComponent
{
	[Position(1)]
	public string LevelOneId { get; set; }

	[Position(2)]
	public string LevelTwoId { get; set; }

	[Position(3)]
	public string LevelThreeId { get; set; }

	[Position(4)]
	public string LevelFourId { get; set; }

	[Position(5)]
	public string LevelFiveId { get; set; }

	[Position(6)]
	public string LevelSixId { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C045_BillLevelIdentification>(this);
		validator.Length(x => x.LevelOneId, 1, 17);
		validator.Length(x => x.LevelTwoId, 1, 17);
		validator.Length(x => x.LevelThreeId, 1, 17);
		validator.Length(x => x.LevelFourId, 1, 17);
		validator.Length(x => x.LevelFiveId, 1, 17);
		validator.Length(x => x.LevelSixId, 1, 17);
		return validator.Results;
	}
}
