using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070.Composites;

[Segment("C041")]
public class C041_CompositeDate : EdiX12Component
{
	[Position(00)]
	public string Date { get; set; }

	[Position(01)]
	public int? Century { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C041_CompositeDate>(this);
		validator.Required(x=>x.Date);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Century, 2);
		return validator.Results;
	}
}
