using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("ORG")]
public class ORG_OriginatorOfRequestDetails : EdifactSegment
{
	[Position(1)]
	public E973_DeliveringSystemDetails DeliveringSystemDetails { get; set; }

	[Position(2)]
	public E974_OriginatorIdentificationDetails OriginatorIdentificationDetails { get; set; }

	[Position(3)]
	public E975_Location Location { get; set; }

	[Position(4)]
	public string PartyName { get; set; }

	[Position(5)]
	public string OriginatorTypeCode { get; set; }

	[Position(6)]
	public E976_OriginatorDetails OriginatorDetails { get; set; }

	[Position(7)]
	public string AccessAuthorisationIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ORG_OriginatorOfRequestDetails>(this);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.OriginatorTypeCode, 1, 3);
		validator.Length(x => x.AccessAuthorisationIdentifier, 1, 9);
		return validator.Results;
	}
}
