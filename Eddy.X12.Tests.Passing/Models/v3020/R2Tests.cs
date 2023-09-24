using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class R2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2*CD*Z*S4*XtCaaJ*u*O*H4*ZC*c*nMEged*J*mH*8";

		var expected = new R2_RouteInformation()
		{
			StandardCarrierAlphaCode = "CD",
			RoutingSequenceCode = "Z",
			CityName = "S4",
			StandardPointLocationCode = "XtCaaJ",
			IntermodalServiceCode = "u",
			TransportationMethodTypeCode = "O",
			IntermediateSwitchCarrier = "H4",
			IntermediateSwitchCarrier2 = "ZC",
			InvoiceNumber = "c",
			Date = "nMEged",
			FreeFormDescription = "J",
			TypeOfServiceCode = "mH",
			RouteDescription = "8",
		};

		var actual = Map.MapObject<R2_RouteInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CD", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.RoutingSequenceCode = "Z";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.StandardCarrierAlphaCode = "CD";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
