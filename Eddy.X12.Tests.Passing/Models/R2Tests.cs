using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class R2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2*Fh*V*d0*iUrQys*X*w*9D*va*C*r02ZyUkg*Y*D6*3";

		var expected = new R2_RouteInformation()
		{
			StandardCarrierAlphaCode = "Fh",
			RoutingSequenceCode = "V",
			CityName = "d0",
			StandardPointLocationCode = "iUrQys",
			IntermodalServiceCode = "X",
			TransportationMethodTypeCode = "w",
			IntermediateSwitchCarrierCode = "9D",
			IntermediateSwitchCarrierCode2 = "va",
			InvoiceNumber = "C",
			Date = "r02ZyUkg",
			FreeFormDescription = "Y",
			TypeOfServiceCode = "D6",
			RouteDescription = "3",
		};

		var actual = Map.MapObject<R2_RouteInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fh", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.RoutingSequenceCode = "V";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.StandardCarrierAlphaCode = "Fh";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "9D", true)]
	[InlineData("va", "", false)]
	public void Validation_ARequiresBIntermediateSwitchCarrierCode2(string intermediateSwitchCarrierCode2, string intermediateSwitchCarrierCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.StandardCarrierAlphaCode = "Fh";
		subject.RoutingSequenceCode = "V";
		subject.IntermediateSwitchCarrierCode2 = intermediateSwitchCarrierCode2;
		subject.IntermediateSwitchCarrierCode = intermediateSwitchCarrierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
