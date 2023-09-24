using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class XBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XB*Ge26L3*G2dw*SU*wG*2b*Lg4cVX";

		var expected = new XB_SwitchRequestInformation()
		{
			Date = "Ge26L3",
			Time = "G2dw",
			Name30CharacterFormat = "SU",
			CityName = "wG",
			StateOrProvinceCode = "2b",
			StandardPointLocationCode = "Lg4cVX",
		};

		var actual = Map.MapObject<XB_SwitchRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
