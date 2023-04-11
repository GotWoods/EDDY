using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SC")]
public class SC_DocketSubLevel : EdiX12Segment
{
	[Position(01)]
	public int? DocketLevelNumber { get; set; }

	[Position(02)]
	public string SubLevel { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SC_DocketSubLevel>(this);
		validator.Required(x=>x.DocketLevelNumber);
		validator.Required(x=>x.SubLevel);
		validator.Length(x => x.DocketLevelNumber, 1, 2);
		validator.Length(x => x.SubLevel, 1, 3);
		return validator.Results;
	}
}
