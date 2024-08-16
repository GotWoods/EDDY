using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C112")]
public class C112_TermsTimeInformation : EdifactComponent
{
	[Position(1)]
	public string TimeReferenceCode { get; set; }

	[Position(2)]
	public string TermsTimeRelationCode { get; set; }

	[Position(3)]
	public string PeriodTypeCode { get; set; }

	[Position(4)]
	public string PeriodCountQuantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C112_TermsTimeInformation>(this);
		validator.Required(x=>x.TimeReferenceCode);
		validator.Length(x => x.TimeReferenceCode, 1, 3);
		validator.Length(x => x.TermsTimeRelationCode, 1, 3);
		validator.Length(x => x.PeriodTypeCode, 1, 3);
		validator.Length(x => x.PeriodCountQuantity, 1, 3);
		return validator.Results;
	}
}
