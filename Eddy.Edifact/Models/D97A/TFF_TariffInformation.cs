using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("TFF")]
public class TFF_TariffInformation : EdifactSegment
{
	[Position(1)]
	public E982_TariffInformation TariffInformation { get; set; }

	[Position(2)]
	public E983_RateInformation RateInformation { get; set; }

	[Position(3)]
	public E984_AssociatedChargesInformation AssociatedChargesInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TFF_TariffInformation>(this);
		return validator.Results;
	}
}
