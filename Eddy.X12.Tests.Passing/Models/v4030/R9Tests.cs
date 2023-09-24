using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class R9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R9*q*y*e*Br*I*I9*i*1*z";

		var expected = new R9_RouteCode()
		{
			RouteCode = "q",
			AgentShipperRoutingCode = "y",
			IntermodalServiceCode = "e",
			StandardCarrierAlphaCode = "Br",
			ActionCode = "I",
			StandardCarrierAlphaCode2 = "I9",
			YesNoConditionOrResponseCode = "i",
			YesNoConditionOrResponseCode2 = "1",
			RouteCode2 = "z",
		};

		var actual = Map.MapObject<R9_RouteCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredRouteCode(string routeCode, bool isValidExpected)
	{
		var subject = new R9_RouteCode();
		subject.RouteCode = routeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "I", true)]
	[InlineData("z", "", false)]
	[InlineData("", "I", true)]
	public void Validation_ARequiresBRouteCode2(string routeCode2, string actionCode, bool isValidExpected)
	{
		var subject = new R9_RouteCode();
		subject.RouteCode = "q";
		subject.RouteCode2 = routeCode2;
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
