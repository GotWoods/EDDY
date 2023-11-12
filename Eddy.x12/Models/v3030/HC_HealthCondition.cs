using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("HC")]
public class HC_HealthCondition : EdiX12Segment
{
	[Position(01)]
	public string DiseaseConditionTypeCode { get; set; }

	[Position(02)]
	public string MedicalTreatmentTypeCode { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HC_HealthCondition>(this);
		validator.Required(x=>x.DiseaseConditionTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.DiseaseConditionTypeCode, 3, 6);
		validator.Length(x => x.MedicalTreatmentTypeCode, 5);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
