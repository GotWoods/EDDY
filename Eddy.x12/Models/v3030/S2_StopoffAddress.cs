using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("S2")]
public class S2_StopOffAddress : EdiX12Segment
{
	[Position(01)]
	public int? StopSequenceNumber { get; set; }

	[Position(02)]
	public string AddressInformation { get; set; }

	[Position(03)]
	public string AddressInformation2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S2_StopOffAddress>(this);
		validator.Required(x=>x.StopSequenceNumber);
		validator.Required(x=>x.AddressInformation);
		validator.Length(x => x.StopSequenceNumber, 1, 2);
		validator.Length(x => x.AddressInformation, 1, 35);
		validator.Length(x => x.AddressInformation2, 1, 35);
		return validator.Results;
	}
}
