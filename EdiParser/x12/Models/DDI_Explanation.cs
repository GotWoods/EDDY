using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("DDI")]
public class DDI_Explanation : EdiX12Segment
{
	[Position(01)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DDI_Explanation>(this);
		validator.Required(x=>x.Description);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
