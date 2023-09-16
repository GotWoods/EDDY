using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class R2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2*fa*b*q4*eKnvSd*6*l*VY*jo*M*kuKPw9aI*c*el*f";

		var expected = new R2_RouteInformation()
		{
			StandardCarrierAlphaCode = "fa",
			RoutingSequenceCode = "b",
			CityName = "q4",
			StandardPointLocationCode = "eKnvSd",
			IntermodalServiceCode = "6",
			TransportationMethodTypeCode = "l",
			IntermediateSwitchCarrierCode = "VY",
			IntermediateSwitchCarrierCode2 = "jo",
			InvoiceNumber = "M",
			Date = "kuKPw9aI",
			FreeFormDescription = "c",
			TypeOfServiceCode = "el",
			RouteDescription = "f",
		};

		var actual = Map.MapObject<R2_RouteInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fa", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.RoutingSequenceCode = "b";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.StandardCarrierAlphaCode = "fa";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jo", "VY", true)]
	[InlineData("jo", "", false)]
	[InlineData("", "VY", true)]
	public void Validation_ARequiresBIntermediateSwitchCarrierCode2(string intermediateSwitchCarrierCode2, string intermediateSwitchCarrierCode, bool isValidExpected)
	{
		var subject = new R2_RouteInformation();
		subject.StandardCarrierAlphaCode = "fa";
		subject.RoutingSequenceCode = "b";
		subject.IntermediateSwitchCarrierCode2 = intermediateSwitchCarrierCode2;
		subject.IntermediateSwitchCarrierCode = intermediateSwitchCarrierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
