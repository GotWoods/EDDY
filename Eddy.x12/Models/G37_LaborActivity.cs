using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G37")]
public class G37_LaborActivity : EdiX12Segment
{
	[Position(01)]
	public string LaborActivityCode { get; set; }

	[Position(02)]
	public string Time { get; set; }

	[Position(03)]
	public string Time2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G37_LaborActivity>(this);
		validator.Required(x=>x.LaborActivityCode);
		validator.ARequiresB(x=>x.Time2, x=>x.Time);
		validator.Length(x => x.LaborActivityCode, 1, 2);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.Time2, 4, 8);
		return validator.Results;
	}
}
