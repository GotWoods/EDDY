using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("ALI")]
public class ALI_AdditionalInformation : EdifactSegment
{
	[Position(1)]
	public string CountryOfOriginCoded { get; set; }

	[Position(2)]
	public string TypeOfDutyRegimeCoded { get; set; }

	[Position(3)]
	public string SpecialConditionCode { get; set; }

	[Position(4)]
	public string SpecialConditionCode2 { get; set; }

	[Position(5)]
	public string SpecialConditionCode3 { get; set; }

	[Position(6)]
	public string SpecialConditionCode4 { get; set; }

	[Position(7)]
	public string SpecialConditionCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ALI_AdditionalInformation>(this);
		validator.Length(x => x.CountryOfOriginCoded, 1, 3);
		validator.Length(x => x.TypeOfDutyRegimeCoded, 1, 3);
		validator.Length(x => x.SpecialConditionCode, 1, 3);
		validator.Length(x => x.SpecialConditionCode2, 1, 3);
		validator.Length(x => x.SpecialConditionCode3, 1, 3);
		validator.Length(x => x.SpecialConditionCode4, 1, 3);
		validator.Length(x => x.SpecialConditionCode5, 1, 3);
		return validator.Results;
	}
}
