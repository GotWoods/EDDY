using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class R9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R9*X*J*K*Fv*j*iG*E*r*x";

		var expected = new R9_RouteCodeIdentification()
		{
			RouteCode = "X",
			AgentShipperRoutingCode = "J",
			IntermodalServiceCode = "K",
			StandardCarrierAlphaCode = "Fv",
			ActionCode = "j",
			StandardCarrierAlphaCode2 = "iG",
			YesNoConditionOrResponseCode = "E",
			YesNoConditionOrResponseCode2 = "r",
			RouteCode2 = "x",
		};

		var actual = Map.MapObject<R9_RouteCodeIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredRouteCode(string routeCode, bool isValidExpected)
	{
		var subject = new R9_RouteCodeIdentification();
		subject.RouteCode = routeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "j", true)]
	[InlineData("x", "", false)]
	public void Validation_ARequiresBRouteCode2(string routeCode2, string actionCode, bool isValidExpected)
	{
		var subject = new R9_RouteCodeIdentification();
		subject.RouteCode = "X";
		subject.RouteCode2 = routeCode2;
		subject.ActionCode = actionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
