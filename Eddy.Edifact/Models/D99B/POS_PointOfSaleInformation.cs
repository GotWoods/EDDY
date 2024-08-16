using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("POS")]
public class POS_PointOfSaleInformation : EdifactSegment
{
	[Position(1)]
	public E032_PartyIdentification PartyIdentification { get; set; }

	[Position(2)]
	public E975_Location Location { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<POS_PointOfSaleInformation>(this);
		return validator.Results;
	}
}
