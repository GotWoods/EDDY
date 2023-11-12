using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class R2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2*7H*4*zG*yjGAI3*G*R*oq*pY*t*xH3PRm*Z*sU*8";

		var expected = new R2_RouteInformation()
		{
			StandardCarrierAlphaCode = "7H",
			RoutingSequenceCode = "4",
			CityName = "zG",
			StandardPointLocationCode = "yjGAI3",
			TOFCIntermodalCodeQualifier = "G",
			TransportationMethodTypeCode = "R",
			IntermediateSwitchCarrier = "oq",
			IntermediateSwitchCarrier2 = "pY",
			InvoiceNumber = "t",
			BillingDate = "xH3PRm",
			FreeFormDescription = "Z",
			TypeOfServiceCode = "sU",
			RouteDescription = "8",
		};

		var actual = Map.MapObject<R2_RouteInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7H", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.RoutingSequenceCode = "4";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.StandardCarrierAlphaCode = "7H";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
