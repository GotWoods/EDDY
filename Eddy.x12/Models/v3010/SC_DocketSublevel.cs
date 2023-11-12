using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("SC")]
public class SC_DocketSubLevel : EdiX12Segment
{
	[Position(01)]
	public int? Level { get; set; }

	[Position(02)]
	public string SubLevel { get; set; }

	[Position(03)]
	public int? AssignedNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SC_DocketSubLevel>(this);
		validator.Required(x=>x.Level);
		validator.Required(x=>x.SubLevel);
		validator.Required(x=>x.AssignedNumber);
		validator.Length(x => x.Level, 1, 2);
		validator.Length(x => x.SubLevel, 1, 3);
		validator.Length(x => x.AssignedNumber, 1, 6);
		return validator.Results;
	}
}
