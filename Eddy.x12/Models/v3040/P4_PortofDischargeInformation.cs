using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("P4")]
public class P4_PortOfDischargeInformation : EdiX12Segment
{
	[Position(01)]
	public string LocationIdentifier { get; set; }

	[Position(02)]
	public string ETADate { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<P4_PortOfDischargeInformation>(this);
		validator.Required(x=>x.LocationIdentifier);
		validator.Required(x=>x.ETADate);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		validator.Length(x => x.ETADate, 6);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
