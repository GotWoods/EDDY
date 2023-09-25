using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("PAT")]
public class PAT_PatientInformation : EdiX12Segment
{
	[Position(01)]
	public string IndividualRelationshipCode { get; set; }

	[Position(02)]
	public string PatientLocationCode { get; set; }

	[Position(03)]
	public string EmploymentStatusCode { get; set; }

	[Position(04)]
	public string StudentStatusCode { get; set; }

	[Position(05)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(06)]
	public string DateTimePeriod { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(08)]
	public decimal? Weight { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PAT_PatientInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Weight);
		validator.Length(x => x.IndividualRelationshipCode, 2);
		validator.Length(x => x.PatientLocationCode, 1);
		validator.Length(x => x.EmploymentStatusCode, 2);
		validator.Length(x => x.StudentStatusCode, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
