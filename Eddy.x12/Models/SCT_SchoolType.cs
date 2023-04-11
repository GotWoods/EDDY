using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

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

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(07)]
	public string InstitutionalGovernanceOrFundingSourceLevelCode { get; set; }

	[Position(08)]
	public string CodeListQualifierCode { get; set; }

	[Position(09)]
	public string IndustryCode { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SCT_SchoolType>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.Length(x => x.AcademicCreditTypeCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.SessionCode, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.InstitutionalGovernanceOrFundingSourceLevelCode, 1);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		return validator.Results;
	}
}
