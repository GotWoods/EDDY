using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class HDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HDI+e+9+k+";

		var expected = new HDI_HardwareDeviceInformation()
		{
			CommunicationNumber = "e",
			DepartmentOrEmployeeIdentification = "9",
			ComputerEnvironmentCoded = "k",
			AttributeInformation = null,
		};

		var actual = Map.MapObject<HDI_HardwareDeviceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
