using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class XETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "XE*c*xC*vB*Lg*1i*3r";

		var expected = new XE_DestinationInformation()
		{
			ReferencedPatternIdentifier = "c",
			CityName = "xC",
			StandardCarrierAlphaCode = "vB",
			Name30CharacterFormat = "Lg",
			DestinationStation = "1i",
			StateOrProvinceCode = "3r",
		};

		var actual = Map.MapObject<XE_DestinationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
