using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("L12")]
public class L12_AlternateLadingDescription : EdiX12Segment
{
	[Position(01)]
	public string LadingDescriptionQualifier { get; set; }

	[Position(02)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L12_AlternateLadingDescription>(this);
		validator.Length(x => x.LadingDescriptionQualifier, 1);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
