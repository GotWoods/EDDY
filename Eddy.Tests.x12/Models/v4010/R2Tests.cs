using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class R2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2*wJ*x*Rf*s8XyOq*r*j*I0*oV*y*1mHWwfxw*q*Nc*5";

		var expected = new R2_RouteInformation()
		{
			StandardCarrierAlphaCode = "wJ",
			RoutingSequenceCode = "x",
			CityName = "Rf",
			StandardPointLocationCode = "s8XyOq",
			IntermodalServiceCode = "r",
			TransportationMethodTypeCode = "j",
			IntermediateSwitchCarrier = "I0",
			IntermediateSwitchCarrier2 = "oV",
			InvoiceNumber = "y",
			Date = "1mHWwfxw",
			FreeFormDescription = "q",
			TypeOfServiceCode = "Nc",
			RouteDescription = "5",
		};

		var actual = Map.MapObject<R2_RouteInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wJ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.RoutingSequenceCode = "x";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.StandardCarrierAlphaCode = "wJ";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oV", "I0", true)]
	[InlineData("oV", "", false)]
	[InlineData("", "I0", true)]
	public void Validation_ARequiresBIntermediateSwitchCarrier2(string intermediateSwitchCarrier2, string intermediateSwitchCarrier, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.StandardCarrierAlphaCode = "wJ";
		subject.RoutingSequenceCode = "x";
		subject.IntermediateSwitchCarrier2 = intermediateSwitchCarrier2;
		subject.IntermediateSwitchCarrier = intermediateSwitchCarrier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
