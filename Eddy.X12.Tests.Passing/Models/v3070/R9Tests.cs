using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class R9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R9*E*o*y*UM*E*ZD*p*d";

		var expected = new R9_RouteCode()
		{
			RouteCode = "E",
			AgentShipperRoutingCode = "o",
			IntermodalServiceCode = "y",
			StandardCarrierAlphaCode = "UM",
			ActionCode = "E",
			StandardCarrierAlphaCode2 = "ZD",
			YesNoConditionOrResponseCode = "p",
			YesNoConditionOrResponseCode2 = "d",
		};

		var actual = Map.MapObject<R9_RouteCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredRouteCode(string routeCode, bool isValidExpected)
	{
		var subject = new R9_RouteCode();
		subject.RouteCode = routeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
