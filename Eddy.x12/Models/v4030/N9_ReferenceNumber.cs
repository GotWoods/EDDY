using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030.Composites;

namespace Eddy.x12.Models.v4030;

[Segment("N9")]
public class N9_ReferenceIdentification : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string FreeFormDescription { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Time { get; set; }

	[Position(06)]
	public string TimeCode { get; set; }

	[Position(07)]
	public C040_ReferenceIdentifier ReferenceIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N9_ReferenceIdentification>(this);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.AtLeastOneIsRequired(x=>x.ReferenceIdentification, x=>x.FreeFormDescription);
		validator.ARequiresB(x=>x.TimeCode, x=>x.Time);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		return validator.Results;
	}
}
