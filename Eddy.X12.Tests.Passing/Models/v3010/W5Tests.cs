using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W5*vt*5X*xN*bY*Nd*w7";

		var expected = new W5_RouteInformation()
		{
			StandardCarrierAlphaCode = "vt",
			CityName = "5X",
			StandardCarrierAlphaCode2 = "xN",
			CityName2 = "bY",
			StandardCarrierAlphaCode3 = "Nd",
			CityName3 = "w7",
		};

		var actual = Map.MapObject<W5_RouteInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vt", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new W5_RouteInformation();
		//Required fields
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
