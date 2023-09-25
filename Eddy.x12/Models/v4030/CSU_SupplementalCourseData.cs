using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("CSU")]
public class CSU_SupplementalCourseData : EdiX12Segment
{
	[Position(01)]
	public string Name { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string DateTimePeriodFormatQualifier2 { get; set; }

	[Position(06)]
	public string DateTimePeriod2 { get; set; }

	[Position(07)]
	public string InstructionalSettingCode { get; set; }

	[Position(08)]
	public string AcademicCreditTypeCode { get; set; }

	[Position(09)]
	public decimal? Quantity { get; set; }

	[Position(10)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CSU_SupplementalCourseData>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier2, x=>x.DateTimePeriod2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Quantity, x=>x.CompositeUnitOfMeasure);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatQualifier2, 2, 3);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.InstructionalSettingCode, 1, 2);
		validator.Length(x => x.AcademicCreditTypeCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
