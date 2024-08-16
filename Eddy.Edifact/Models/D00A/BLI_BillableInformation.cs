using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("BLI")]
public class BLI_BillableInformation : EdifactSegment
{
	[Position(1)]
	public string MonetaryAmount { get; set; }

	[Position(2)]
	public E029_Diagnosis Diagnosis { get; set; }

	[Position(3)]
	public E507_DateTimePeriod DateTimePeriod { get; set; }

	[Position(4)]
	public string ObjectIdentifier { get; set; }

	[Position(5)]
	public string YesOrNoIndicatorCode { get; set; }

	[Position(6)]
	public E028_RelatedCause RelatedCause { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BLI_BillableInformation>(this);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.ObjectIdentifier, 1, 35);
		validator.Length(x => x.YesOrNoIndicatorCode, 1, 3);
		return validator.Results;
	}
}
