using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("SG")]
public class SG_ShipmentStatus : EdiX12Segment
{
	[Position(01)]
	public string ShipmentStatusCode { get; set; }

	[Position(02)]
	public string StatusReasonCode { get; set; }

	[Position(03)]
	public string DispositionCode { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Time { get; set; }

	[Position(06)]
	public string TimeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SG_ShipmentStatus>(this);
		validator.ARequiresB(x=>x.TimeCode, x=>x.Time);
		validator.Length(x => x.ShipmentStatusCode, 1, 2);
		validator.Length(x => x.StatusReasonCode, 3);
		validator.Length(x => x.DispositionCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		return validator.Results;
	}
}
