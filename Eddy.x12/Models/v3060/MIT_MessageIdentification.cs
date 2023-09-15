using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("MIT")]
public class MIT_MessageIdentification : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string Description { get; set; }

	[Position(03)]
	public int? PageWidth { get; set; }

	[Position(04)]
	public int? PageLengthLines { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MIT_MessageIdentification>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.PageWidth, 1, 3);
		validator.Length(x => x.PageLengthLines, 1, 3);
		return validator.Results;
	}
}
