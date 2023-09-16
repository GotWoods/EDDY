using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("P4")]
public class P4_USPortInformation : EdiX12Segment
{
	[Position(01)]
	public string LocationIdentifier { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public string LocationIdentifier2 { get; set; }

	[Position(05)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<P4_USPortInformation>(this);
		validator.Required(x=>x.LocationIdentifier);
		validator.Required(x=>x.Date);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.LocationIdentifier2, 1, 30);
		validator.Length(x => x.Time, 4, 8);
		return validator.Results;
	}
}
