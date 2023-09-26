using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("LFI")]
public class LFI_BeginningSegmentForLocomotiveInformation : EdiX12Segment
{
	[Position(01)]
	public string StandardPointLocationCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Time { get; set; }

	[Position(04)]
	public string EquipmentStatusCode { get; set; }

	[Position(05)]
	public string IndustryCode { get; set; }

	[Position(06)]
	public string IndustryCode2 { get; set; }

	[Position(07)]
	public string IndustryCode3 { get; set; }

	[Position(08)]
	public string InterchangeTrainIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LFI_BeginningSegmentForLocomotiveInformation>(this);
		validator.Required(x=>x.StandardPointLocationCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Time);
		validator.Required(x=>x.EquipmentStatusCode);
		validator.Required(x=>x.IndustryCode);
		validator.Length(x => x.StandardPointLocationCode, 6, 9);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.EquipmentStatusCode, 1, 2);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.IndustryCode2, 1, 30);
		validator.Length(x => x.IndustryCode3, 1, 30);
		validator.Length(x => x.InterchangeTrainIdentification, 1, 10);
		return validator.Results;
	}
}
