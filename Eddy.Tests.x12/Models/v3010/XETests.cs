using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class XETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XE*v*IW*vd*fx*oY*KA";

		var expected = new XE_DestinationInformation()
		{
			ReferencedPatternIdentifier = "v",
			CityName = "IW",
			StandardCarrierAlphaCode = "vd",
			Name30CharacterFormat = "fx",
			DestinationStation = "oY",
			StateOrProvinceCode = "KA",
		};

		var actual = Map.MapObject<XE_DestinationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
