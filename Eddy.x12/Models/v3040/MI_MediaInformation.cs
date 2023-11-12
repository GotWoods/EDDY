using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("MI")]
public class MI_MediaInformation : EdiX12Segment
{
	[Position(01)]
	public string MediaTypeIdentifier { get; set; }

	[Position(02)]
	public string Amount { get; set; }

	[Position(03)]
	public string Amount2 { get; set; }

	[Position(04)]
	public string Amount3 { get; set; }

	[Position(05)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MI_MediaInformation>(this);
		validator.Required(x=>x.MediaTypeIdentifier);
		validator.Length(x => x.MediaTypeIdentifier, 2);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.Amount2, 1, 15);
		validator.Length(x => x.Amount3, 1, 15);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
