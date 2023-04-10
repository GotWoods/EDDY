using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("DEG")]
public class DEG_DegreeRecord : EdiX12Segment
{
	[Position(01)]
	public string AcademicDegreeCode { get; set; }

	[Position(02)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriod { get; set; }

	[Position(04)]
	public string Description { get; set; }

	[Position(05)]
	public string StatusReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DEG_DegreeRecord>(this);
		validator.Required(x=>x.AcademicDegreeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.AcademicDegreeCode, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.StatusReasonCode, 3);
		return validator.Results;
	}
}
