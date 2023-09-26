using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("CR6")]
public class CR6_HomeHealthCareCertification : EdiX12Segment
{
	[Position(01)]
	public string PrognosisCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(08)]
	public string CertificationTypeCode { get; set; }

	[Position(09)]
	public string Date3 { get; set; }

	[Position(10)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(11)]
	public string MedicalCodeValue { get; set; }

	[Position(12)]
	public string Date4 { get; set; }

	[Position(13)]
	public string Date5 { get; set; }

	[Position(14)]
	public string Date6 { get; set; }

	[Position(15)]
	public string DateTimePeriodFormatQualifier2 { get; set; }

	[Position(16)]
	public string DateTimePeriod2 { get; set; }

	[Position(17)]
	public string PatientLocationCode { get; set; }

	[Position(18)]
	public string Date7 { get; set; }

	[Position(19)]
	public string Date8 { get; set; }

	[Position(20)]
	public string Date9 { get; set; }

	[Position(21)]
	public string Date10 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CR6_HomeHealthCareCertification>(this);
		validator.Required(x=>x.PrognosisCode);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Required(x=>x.YesNoConditionOrResponseCode2);
		validator.Required(x=>x.CertificationTypeCode);
		validator.Length(x => x.PrognosisCode, 1);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.CertificationTypeCode, 1);
		validator.Length(x => x.Date3, 8);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.MedicalCodeValue, 1, 15);
		validator.Length(x => x.Date4, 8);
		validator.Length(x => x.Date5, 8);
		validator.Length(x => x.Date6, 8);
		validator.Length(x => x.DateTimePeriodFormatQualifier2, 2, 3);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.PatientLocationCode, 1);
		validator.Length(x => x.Date7, 8);
		validator.Length(x => x.Date8, 8);
		validator.Length(x => x.Date9, 8);
		validator.Length(x => x.Date10, 8);
		return validator.Results;
	}
}
