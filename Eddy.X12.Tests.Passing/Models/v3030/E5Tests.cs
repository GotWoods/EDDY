using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class E5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E5*zr*E*iz*DXynCu";

		var expected = new E5_EmptyCarDispositionPendedDestinationRoute()
		{
			StandardCarrierAlphaCode = "zr",
			RoutingSequenceCode = "E",
			CityName = "iz",
			StandardPointLocationCode = "DXynCu",
		};

		var actual = Map.MapObject<E5_EmptyCarDispositionPendedDestinationRoute>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zr", true)]
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
		subject.StandardCarrierAlphaCode = "zr";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
