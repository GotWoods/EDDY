using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SMO")]
public class SMO_OperationalServices : EdiX12Segment
{
	[Position(01)]
	public string AutomobileRampFacilityCode { get; set; }

	[Position(02)]
	public string IntermodalFacilityCode { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(05)]
	public decimal? Weight { get; set; }

	[Position(06)]
	public string RailCarPlateSizeCode { get; set; }

	[Position(07)]
	public string ImportExportCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SMO_OperationalServices>(this);
		validator.Length(x => x.AutomobileRampFacilityCode, 1);
		validator.Length(x => x.IntermodalFacilityCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.RailCarPlateSizeCode, 1);
		validator.Length(x => x.ImportExportCode, 1);
		return validator.Results;
	}
}
