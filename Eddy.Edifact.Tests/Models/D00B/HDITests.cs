using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B;

public class HDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HDI+1+v+E+";

		var expected = new HDI_HardwareDeviceInformation()
		{
			CommunicationAddressIdentifier = "1",
			DepartmentOrEmployeeNameCode = "v",
			ComputerEnvironmentNameCode = "E",
			AttributeInformation = null,
		};

		var actual = Map.MapObject<HDI_HardwareDeviceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
