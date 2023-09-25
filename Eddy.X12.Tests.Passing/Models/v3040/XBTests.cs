using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class XBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XB*xd7Zns*QndR*dv*sg*sE*YWpIf8";

		var expected = new XB_SwitchRequestInformation()
		{
			Date = "xd7Zns",
			Time = "QndR",
			Name30CharacterFormat = "dv",
			CityName = "sg",
			StateOrProvinceCode = "sE",
			StandardPointLocationCode = "YWpIf8",
		};

		var actual = Map.MapObject<XB_SwitchRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
