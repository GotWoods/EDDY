using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W5*i4*zm*nk*EE*3T*Pa";

		var expected = new W5_CarrierAndRouteInformation()
		{
			StandardCarrierAlphaCode = "i4",
			CityName = "zm",
			StandardCarrierAlphaCode2 = "nk",
			CityName2 = "EE",
			StandardCarrierAlphaCode3 = "3T",
			CityName3 = "Pa",
		};

		var actual = Map.MapObject<W5_CarrierAndRouteInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i4", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new W5_CarrierAndRouteInformation();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
