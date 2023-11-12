using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("M3")]
public class M3_Release : EdiX12Segment
{
	[Position(01)]
	public string ReleaseCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string TimeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<M3_Release>(this);
		validator.Required(x=>x.ReleaseCode);
		validator.ARequiresB(x=>x.TimeCode, x=>x.Time);
		validator.Length(x => x.ReleaseCode, 1);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		return validator.Results;
	}
}
