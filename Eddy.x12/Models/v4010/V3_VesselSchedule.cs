using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("V3")]
public class V3_VesselSchedule : EdiX12Segment
{
	[Position(01)]
	public string CurrentPortOfLoading { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string NextPortOfDischarge { get; set; }

	[Position(04)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<V3_VesselSchedule>(this);
		validator.Required(x=>x.CurrentPortOfLoading);
		validator.Required(x=>x.Date);
		validator.Length(x => x.CurrentPortOfLoading, 2, 24);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.NextPortOfDischarge, 2, 24);
		validator.Length(x => x.Date2, 8);
		return validator.Results;
	}
}
