using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LEP*6lKf*Xn6uFtDUwsvj7g";

		var expected = new LEP_EPARequiredData()
		{
			EPAWasteStreamNumberCode = "6lKf",
			WasteCharacteristicsCode = "Xn6uFtDUwsvj7g",
		};

		var actual = Map.MapObject<LEP_EPARequiredData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
