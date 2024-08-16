using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("HDI")]
public class HDI_HardwareDeviceInformation : EdifactSegment
{
	[Position(1)]
	public string CommunicationNumber { get; set; }

	[Position(2)]
	public string DepartmentOrEmployeeNameCode { get; set; }

	[Position(3)]
	public string ComputerEnvironmentNameCode { get; set; }

	[Position(4)]
	public E003_AttributeInformation AttributeInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HDI_HardwareDeviceInformation>(this);
		validator.Length(x => x.CommunicationNumber, 1, 512);
		validator.Length(x => x.DepartmentOrEmployeeNameCode, 1, 17);
		validator.Length(x => x.ComputerEnvironmentNameCode, 1, 3);
		return validator.Results;
	}
}
