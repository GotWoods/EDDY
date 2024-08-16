using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("GIR")]
public class GIR_RelatedIdentificationNumbers : EdifactSegment
{
	[Position(1)]
	public string SetIdentificationQualifier { get; set; }

	[Position(2)]
	public C206_IdentificationNumber IdentificationNumber { get; set; }

	[Position(3)]
	public C206_IdentificationNumber IdentificationNumber2 { get; set; }

	[Position(4)]
	public C206_IdentificationNumber IdentificationNumber3 { get; set; }

	[Position(5)]
	public C206_IdentificationNumber IdentificationNumber4 { get; set; }

	[Position(6)]
	public C206_IdentificationNumber IdentificationNumber5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GIR_RelatedIdentificationNumbers>(this);
		validator.Required(x=>x.SetIdentificationQualifier);
		validator.Required(x=>x.IdentificationNumber);
		validator.Length(x => x.SetIdentificationQualifier, 1, 3);
		return validator.Results;
	}
}
