using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("MCZ")]
public class MCZ_MarineCatchZone : EdiX12Segment
{
	[Position(01)]
	public string MarineCatchZone { get; set; }

	[Position(02)]
	public string Date { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MCZ_MarineCatchZone>(this);
		validator.Required(x=>x.MarineCatchZone);
		validator.Length(x => x.MarineCatchZone, 2, 3);
		validator.Length(x => x.Date, 8);
		return validator.Results;
	}
}
