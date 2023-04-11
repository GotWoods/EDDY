using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("HAD")]
public class HAD_HospitalAffiliationDetail : EdiX12Segment
{
	[Position(01)]
	public string StatusCode { get; set; }

	[Position(02)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(05)]
	public string CodeListQualifierCode { get; set; }

	[Position(06)]
	public string IndustryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HAD_HospitalAffiliationDetail>(this);
		validator.Required(x=>x.StatusCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.Length(x => x.StatusCode, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		return validator.Results;
	}
}
