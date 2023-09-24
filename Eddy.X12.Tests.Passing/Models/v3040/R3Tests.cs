using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class R3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R3*ao*m*CZ*t*XHXXBn*X*z4WUVp*O*Y";

		var expected = new R3_RouteInformationMotor()
		{
			StandardCarrierAlphaCode = "ao",
			RoutingSequenceCode = "m",
			CityName = "CZ",
			TransportationMethodTypeCode = "t",
			StandardPointLocationCode = "XHXXBn",
			InvoiceNumber = "X",
			Date = "z4WUVp",
			Amount = "O",
			FreeFormDescription = "Y",
		};

		var actual = Map.MapObject<R3_RouteInformationMotor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ao", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new R3_RouteInformationMotor();
		subject.RoutingSequenceCode = "m";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R3_RouteInformationMotor();
		subject.StandardCarrierAlphaCode = "ao";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
