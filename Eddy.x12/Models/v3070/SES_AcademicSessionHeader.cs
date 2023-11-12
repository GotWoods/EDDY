using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("SES")]
public class SES_AcademicSessionHeader : EdiX12Segment
{
	[Position(01)]
	public string DateTimePeriod { get; set; }

	[Position(02)]
	public int? Count { get; set; }

	[Position(03)]
	public string DateTimePeriod2 { get; set; }

	[Position(04)]
	public string SessionCode { get; set; }

	[Position(05)]
	public string Name { get; set; }

	[Position(06)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(07)]
	public string DateTimePeriod3 { get; set; }

	[Position(08)]
	public string DateTimePeriodFormatQualifier2 { get; set; }

	[Position(09)]
	public string DateTimePeriod4 { get; set; }

	[Position(10)]
	public string LevelOfIndividualTestOrCourseCode { get; set; }

	[Position(11)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(12)]
	public string IdentificationCode { get; set; }

	[Position(13)]
	public string Name2 { get; set; }

	[Position(14)]
	public string StatusReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SES_AcademicSessionHeader>(this);
		validator.Required(x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier2, x=>x.DateTimePeriod4);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.Count, 1, 9);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.SessionCode, 1);
		validator.Length(x => x.Name, 1, 60);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod3, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatQualifier2, 2, 3);
		validator.Length(x => x.DateTimePeriod4, 1, 35);
		validator.Length(x => x.LevelOfIndividualTestOrCourseCode, 2);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.Name2, 1, 60);
		validator.Length(x => x.StatusReasonCode, 3);
		return validator.Results;
	}
}
