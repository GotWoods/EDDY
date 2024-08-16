using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("BLI")]
public class BLI_BillableInformation : EdifactSegment
{
	[Position(1)]
	public string MonetaryAmountValue { get; set; }

	[Position(2)]
	public E029_Diagnosis Diagnosis { get; set; }

	[Position(3)]
	public E507_DateTimePeriod DateTimePeriod { get; set; }

	[Position(4)]
	public string ObjectIdentifier { get; set; }

	[Position(5)]
	public string YesNoCode { get; set; }

	[Position(6)]
	public E028_RelatedCause RelatedCause { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BLI_BillableInformation>(this);
		validator.Length(x => x.MonetaryAmountValue, 1, 35);
		validator.Length(x => x.ObjectIdentifier, 1, 35);
		validator.Length(x => x.YesNoCode, 1, 3);
		return validator.Results;
	}
}
