using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class R3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R3*Uw*0*bo*x*sJWE7N*U*YGEzYn*N*F";

		var expected = new R3_RouteInformationMotor()
		{
			StandardCarrierAlphaCode = "Uw",
			RoutingSequenceCode = "0",
			CityName = "bo",
			TransportationMethodTypeCode = "x",
			StandardPointLocationCode = "sJWE7N",
			InvoiceNumber = "U",
			Date = "YGEzYn",
			Amount = "N",
			FreeFormDescription = "F",
		};

		var actual = Map.MapObject<R3_RouteInformationMotor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Uw", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new R3_RouteInformationMotor();
		subject.RoutingSequenceCode = "0";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R3_RouteInformationMotor();
		subject.StandardCarrierAlphaCode = "Uw";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
