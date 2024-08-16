using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class HDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HDI+E+M+F+";

		var expected = new HDI_HardwareDeviceInformation()
		{
			CommunicationAddressIdentifier = "E",
			ContactIdentifier = "M",
			ComputerEnvironmentNameCode = "F",
			AttributeInformation = null,
		};

		var actual = Map.MapObject<HDI_HardwareDeviceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
