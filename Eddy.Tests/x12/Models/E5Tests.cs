using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class E5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E5*x8*E*L9*LDwiOX";

		var expected = new E5_EmptyCarDispositionPendedDestinationRoute()
		{
			StandardCarrierAlphaCode = "x8",
			RoutingSequenceCode = "E",
			CityName = "L9",
			StandardPointLocationCode = "LDwiOX",
		};

		var actual = Map.MapObject<E5_EmptyCarDispositionPendedDestinationRoute>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x8", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new E5_EmptyCarDispositionPendedDestinationRoute();
		subject.RoutingSequenceCode = "E";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new E5_EmptyCarDispositionPendedDestinationRoute();
		subject.StandardCarrierAlphaCode = "x8";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
