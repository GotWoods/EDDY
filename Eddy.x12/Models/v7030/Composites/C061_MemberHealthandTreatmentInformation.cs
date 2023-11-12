using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7030.Composites;

[Segment("C061")]
public class C061_MemberHealthAndTreatmentInformation : EdiX12Component
{
	[Position(00)]
	public string HealthRelatedCode { get; set; }

	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string DateTimeQualifier { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C061_MemberHealthAndTreatmentInformation>(this);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimeQualifier, x=>x.Date, x=>x.Date2);
		validator.ARequiresB(x=>x.Date, x=>x.DateTimeQualifier);
		validator.ARequiresB(x=>x.Date2, x=>x.DateTimeQualifier);
		validator.Length(x => x.HealthRelatedCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		return validator.Results;
	}
}
