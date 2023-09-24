using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class R9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R9*Z*s*z*tM*i*XX*V";

		var expected = new R9_RouteCode()
		{
			RouteCode = "Z",
			AgentShipperRoutingCode = "s",
			IntermodalServiceCode = "z",
			StandardCarrierAlphaCode = "tM",
			ActionCode = "i",
			StandardCarrierAlphaCode2 = "XX",
			YesNoConditionOrResponseCode = "V",
		};

		var actual = Map.MapObject<R9_RouteCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredRouteCode(string routeCode, bool isValidExpected)
	{
		var subject = new R9_RouteCode();
		subject.RouteCode = routeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
