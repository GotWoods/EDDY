using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("ALI")]
public class ALI_AdditionalInformation : EdifactSegment
{
	[Position(1)]
	public string CountryOfOriginCoded { get; set; }

	[Position(2)]
	public string TypeOfDutyRegimeCoded { get; set; }

	[Position(3)]
	public string SpecialConditionsCoded { get; set; }

	[Position(4)]
	public string SpecialConditionsCoded2 { get; set; }

	[Position(5)]
	public string SpecialConditionsCoded3 { get; set; }

	[Position(6)]
	public string SpecialConditionsCoded4 { get; set; }

	[Position(7)]
	public string SpecialConditionsCoded5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ALI_AdditionalInformation>(this);
		validator.Length(x => x.CountryOfOriginCoded, 1, 3);
		validator.Length(x => x.TypeOfDutyRegimeCoded, 1, 3);
		validator.Length(x => x.SpecialConditionsCoded, 1, 3);
		validator.Length(x => x.SpecialConditionsCoded2, 1, 3);
		validator.Length(x => x.SpecialConditionsCoded3, 1, 3);
		validator.Length(x => x.SpecialConditionsCoded4, 1, 3);
		validator.Length(x => x.SpecialConditionsCoded5, 1, 3);
		return validator.Results;
	}
}
