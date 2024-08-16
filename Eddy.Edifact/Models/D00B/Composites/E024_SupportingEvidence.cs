using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("E024")]
public class E024_SupportingEvidence : EdifactComponent
{
	[Position(1)]
	public string SupportingEvidenceTypeCodeQualifier { get; set; }

	[Position(2)]
	public string ReferenceIdentifier { get; set; }

	[Position(3)]
	public string CommunicationMediumTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E024_SupportingEvidence>(this);
		validator.Required(x=>x.SupportingEvidenceTypeCodeQualifier);
		validator.Required(x=>x.ReferenceIdentifier);
		validator.Length(x => x.SupportingEvidenceTypeCodeQualifier, 1, 3);
		validator.Length(x => x.ReferenceIdentifier, 1, 70);
		validator.Length(x => x.CommunicationMediumTypeCode, 1, 3);
		return validator.Results;
	}
}
