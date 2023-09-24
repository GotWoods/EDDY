using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class XBTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XB*A5TVZC*hZsK*JZ*OE*fw*yqwNpb";

		var expected = new XB_SwitchRequestInformation()
		{
			Date = "A5TVZC",
			Time = "hZsK",
			Name30CharacterFormat = "JZ",
			CityName = "OE",
			StateOrProvinceCode = "fw",
			StandardPointLocationCode = "yqwNpb",
		};

		var actual = Map.MapObject<XB_SwitchRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
