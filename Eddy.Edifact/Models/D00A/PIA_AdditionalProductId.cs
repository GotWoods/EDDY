using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("PIA")]
public class PIA_AdditionalProductId : EdifactSegment
{
	[Position(1)]
	public string ProductIdentifierCodeQualifier { get; set; }

	[Position(2)]
	public C212_ItemNumberIdentification ItemNumberIdentification { get; set; }

	[Position(3)]
	public C212_ItemNumberIdentification ItemNumberIdentification2 { get; set; }

	[Position(4)]
	public C212_ItemNumberIdentification ItemNumberIdentification3 { get; set; }

	[Position(5)]
	public C212_ItemNumberIdentification ItemNumberIdentification4 { get; set; }

	[Position(6)]
	public C212_ItemNumberIdentification ItemNumberIdentification5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PIA_AdditionalProductId>(this);
		validator.Required(x=>x.ProductIdentifierCodeQualifier);
		validator.Required(x=>x.ItemNumberIdentification);
		validator.Length(x => x.ProductIdentifierCodeQualifier, 1, 3);
		return validator.Results;
	}
}
