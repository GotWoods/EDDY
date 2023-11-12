using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("N3")]
public class N3_AddressInformation : EdiX12Segment
{
	[Position(01)]
	public string AddressInformation { get; set; }

	[Position(02)]
	public string AddressInformation2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N3_AddressInformation>(this);
		validator.Required(x=>x.AddressInformation);
		validator.Length(x => x.AddressInformation, 1, 55);
		validator.Length(x => x.AddressInformation2, 1, 55);
		return validator.Results;
	}
}
