using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("PCL")]
public class PCL_PreviousCollege : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(02)]
	public string IdentificationCode { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string AcademicDegreeCode { get; set; }

	[Position(06)]
	public string DateTimePeriod2 { get; set; }

	[Position(07)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PCL_PreviousCollege>(this);
		validator.AtLeastOneIsRequired(x=>x.IdentificationCodeQualifier, x=>x.Description);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.ARequiresB(x=>x.DateTimePeriod2, x=>x.AcademicDegreeCode);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.AcademicDegreeCode, 3);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
