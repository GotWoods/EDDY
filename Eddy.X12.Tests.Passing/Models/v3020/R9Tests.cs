using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class R9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R9*Y*J*v*Cz";

		var expected = new R9_RouteCode()
		{
			RouteCode = "Y",
			AgentShipperRoutingCode = "J",
			IntermodalServiceCode = "v",
			StandardCarrierAlphaCode = "Cz",
		};

		var actual = Map.MapObject<R9_RouteCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredRouteCode(string routeCode, bool isValidExpected)
	{
		var subject = new R9_RouteCode();
		subject.AgentShipperRoutingCode = "J";
		subject.RouteCode = routeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredAgentShipperRoutingCode(string agentShipperRoutingCode, bool isValidExpected)
	{
		var subject = new R9_RouteCode();
		subject.RouteCode = "Y";
		subject.AgentShipperRoutingCode = agentShipperRoutingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
