using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E967")]
public class E967_ConsumerReferenceIdentification : EdifactComponent
{
	[Position(1)]
	public string ReferenceFunctionCodeQualifier { get; set; }

	[Position(2)]
	public string ReferenceIdentifier { get; set; }

	[Position(3)]
	public string PartyName { get; set; }

	[Position(4)]
	public string TravellerReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E967_ConsumerReferenceIdentification>(this);
		validator.Required(x=>x.ReferenceFunctionCodeQualifier);
		validator.Length(x => x.ReferenceFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.ReferenceIdentifier, 1, 35);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.TravellerReferenceNumber, 1, 35);
		return validator.Results;
	}
}