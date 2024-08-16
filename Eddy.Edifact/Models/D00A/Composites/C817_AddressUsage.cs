using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C817")]
public class C817_AddressUsage : EdifactComponent
{
	[Position(1)]
	public string AddressPurposeCode { get; set; }

	[Position(2)]
	public string AddressTypeCode { get; set; }

	[Position(3)]
	public string AddressStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C817_AddressUsage>(this);
		validator.Length(x => x.AddressPurposeCode, 1, 3);
		validator.Length(x => x.AddressTypeCode, 1, 3);
		validator.Length(x => x.AddressStatusCode, 1, 3);
		return validator.Results;
	}
}
