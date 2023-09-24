using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class R3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R3*98*C*HW*a*8nvh3I*q*rMWiO9*A*R";

		var expected = new R3_RouteInformationMotor()
		{
			StandardCarrierAlphaCode = "98",
			RoutingSequenceCode = "C",
			CityName = "HW",
			TransportationMethodTypeCode = "a",
			StandardPointLocationCode = "8nvh3I",
			InvoiceNumber = "q",
			Date = "rMWiO9",
			Amount = "A",
			FreeFormDescription = "R",
		};

		var actual = Map.MapObject<R3_RouteInformationMotor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("98", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new R3_RouteInformationMotor();
		subject.RoutingSequenceCode = "C";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R3_RouteInformationMotor();
		subject.StandardCarrierAlphaCode = "98";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
