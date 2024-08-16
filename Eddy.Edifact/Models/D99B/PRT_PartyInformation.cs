using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("PRT")]
public class PRT_PartyInformation : EdifactSegment
{
	[Position(1)]
	public string PartyFunctionCodeQualifier { get; set; }

	[Position(2)]
	public E206_ObjectIdentification ObjectIdentification { get; set; }

	[Position(3)]
	public string DateValue { get; set; }

	[Position(4)]
	public E023_PartyDemographicInformation PartyDemographicInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRT_PartyInformation>(this);
		validator.Required(x=>x.PartyFunctionCodeQualifier);
		validator.Length(x => x.PartyFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.DateValue, 1, 14);
		return validator.Results;
	}
}
