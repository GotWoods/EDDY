using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G69")]
public class G69_LineItemDetailDescription : EdiX12Segment
{
	[Position(01)]
	public string FreeFormDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G69_LineItemDetailDescription>(this);
		validator.Required(x=>x.FreeFormDescription);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		return validator.Results;
	}
}
