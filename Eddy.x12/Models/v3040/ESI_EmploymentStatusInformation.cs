using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("ESI")]
public class ESI_EmploymentStatusInformation : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(04)]
	public string Time { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string EmploymentStatusCode { get; set; }

	[Position(07)]
	public string WorkIntensityCode { get; set; }

	[Position(08)]
	public string ReasonStoppedWorkCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ESI_EmploymentStatusInformation>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.EmploymentStatusCode, 2);
		validator.Length(x => x.WorkIntensityCode, 1);
		validator.Length(x => x.ReasonStoppedWorkCode, 2);
		return validator.Results;
	}
}
