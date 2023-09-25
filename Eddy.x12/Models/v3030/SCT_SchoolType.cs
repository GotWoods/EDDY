using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("SCT")]
public class SCT_SchoolType : EdiX12Segment
{
	[Position(01)]
	public string AcademicCreditTypeCode { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string SessionCode { get; set; }

	[Position(04)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(05)]
	public string DateTimePeriod { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCT_SchoolType>(this);
		validator.Length(x => x.AcademicCreditTypeCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.SessionCode, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		return validator.Results;
	}
}
