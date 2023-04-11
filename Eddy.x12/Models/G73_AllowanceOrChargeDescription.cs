using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G73")]
public class G73_AllowanceOrChargeDescription : EdiX12Segment
{
	[Position(01)]
	public string FreeFormDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G73_AllowanceOrChargeDescription>(this);
		validator.Required(x=>x.FreeFormDescription);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		return validator.Results;
	}
}
