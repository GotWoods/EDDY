using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C112")]
public class C112_TermsTimeInformation : EdifactComponent
{
	[Position(1)]
	public string PaymentTimeReferenceCoded { get; set; }

	[Position(2)]
	public string TimeRelationCoded { get; set; }

	[Position(3)]
	public string TypeOfPeriodCoded { get; set; }

	[Position(4)]
	public string NumberOfPeriods { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C112_TermsTimeInformation>(this);
		validator.Required(x=>x.PaymentTimeReferenceCoded);
		validator.Length(x => x.PaymentTimeReferenceCoded, 1, 3);
		validator.Length(x => x.TimeRelationCoded, 1, 3);
		validator.Length(x => x.TypeOfPeriodCoded, 1, 3);
		validator.Length(x => x.NumberOfPeriods, 1, 3);
		return validator.Results;
	}
}
