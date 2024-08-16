using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class HDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HDI+C+A+c+";

		var expected = new HDI_HardwareDeviceInformation()
		{
			CommunicationNumber = "C",
			DepartmentOrEmployeeNameCode = "A",
			ComputerEnvironmentNameCode = "c",
			AttributeInformation = null,
		};

		var actual = Map.MapObject<HDI_HardwareDeviceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
