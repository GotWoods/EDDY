using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class R2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2*dm*Y*R5*FFHsAK*8*U*2G*mU*E*Fdjsqc*W*p5*j";

		var expected = new R2_RouteInformation()
		{
			StandardCarrierAlphaCode = "dm",
			RoutingSequenceCode = "Y",
			CityName = "R5",
			StandardPointLocationCode = "FFHsAK",
			IntermodalServiceCode = "8",
			TransportationMethodTypeCode = "U",
			IntermediateSwitchCarrier = "2G",
			IntermediateSwitchCarrier2 = "mU",
			InvoiceNumber = "E",
			Date = "Fdjsqc",
			FreeFormDescription = "W",
			TypeOfServiceCode = "p5",
			RouteDescription = "j",
		};

		var actual = Map.MapObject<R2_RouteInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dm", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.RoutingSequenceCode = "Y";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.StandardCarrierAlphaCode = "dm";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
