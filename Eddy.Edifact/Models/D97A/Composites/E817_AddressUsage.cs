using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E817")]
public class E817_AddressUsage : EdifactComponent
{
	[Position(1)]
	public string AddressPurposeCoded { get; set; }

	[Position(2)]
	public string AddressTypeCoded { get; set; }

	[Position(3)]
	public string AddressStatusCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E817_AddressUsage>(this);
		validator.Length(x => x.AddressPurposeCoded, 1, 3);
		validator.Length(x => x.AddressTypeCoded, 1, 3);
		validator.Length(x => x.AddressStatusCoded, 1, 3);
		return validator.Results;
	}
}
