using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Models.D06A;

[Segment("HDI")]
public class HDI_HardwareDeviceInformation : EdifactSegment
{
	[Position(1)]
	public string CommunicationAddressIdentifier { get; set; }

	[Position(2)]
	public string ContactIdentifier { get; set; }

	[Position(3)]
	public string ComputerEnvironmentNameCode { get; set; }

	[Position(4)]
	public E003_AttributeInformation AttributeInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HDI_HardwareDeviceInformation>(this);
		validator.Length(x => x.CommunicationAddressIdentifier, 1, 512);
		validator.Length(x => x.ContactIdentifier, 1, 17);
		validator.Length(x => x.ComputerEnvironmentNameCode, 1, 3);
		return validator.Results;
	}
}
