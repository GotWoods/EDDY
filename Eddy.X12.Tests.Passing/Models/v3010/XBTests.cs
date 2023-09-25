using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class XBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XB*eHKddv*QiGi*6L*FN*cG*mGM5yo";

		var expected = new XB_SwitchRequestInformation()
		{
			Date = "eHKddv",
			Time = "QiGi",
			Name30CharacterFormat = "6L",
			CityName = "FN",
			StateOrProvinceCode = "cG",
			StandardPointLocationCode = "mGM5yo",
		};

		var actual = Map.MapObject<XB_SwitchRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
