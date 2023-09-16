using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class R3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R3*P5*K*Xy*V*eAcky8*A*8JBTtVJL*a*T*c5*Ax*de";

		var expected = new R3_RouteInformationMotor()
		{
			StandardCarrierAlphaCode = "P5",
			RoutingSequenceCode = "K",
			CityName = "Xy",
			TransportationMethodTypeCode = "V",
			StandardPointLocationCode = "eAcky8",
			InvoiceNumber = "A",
			Date = "8JBTtVJL",
			Amount = "a",
			FreeFormDescription = "T",
			ServiceLevelCode = "c5",
			ServiceLevelCode2 = "Ax",
			ServiceLevelCode3 = "de",
		};

		var actual = Map.MapObject<R3_RouteInformationMotor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P5", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new R3_RouteInformationMotor();
		subject.RoutingSequenceCode = "K";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new R3_RouteInformationMotor();
		subject.StandardCarrierAlphaCode = "P5";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ax", "c5", true)]
	[InlineData("Ax", "", false)]
	[InlineData("", "c5", true)]
	public void Validation_ARequiresBServiceLevelCode2(string serviceLevelCode2, string serviceLevelCode, bool isValidExpected)
	{
		var subject = new R3_RouteInformationMotor();
		subject.StandardCarrierAlphaCode = "P5";
		subject.RoutingSequenceCode = "K";
		subject.ServiceLevelCode2 = serviceLevelCode2;
		subject.ServiceLevelCode = serviceLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("de", "Ax", true)]
	[InlineData("de", "", false)]
	[InlineData("", "Ax", true)]
	public void Validation_ARequiresBServiceLevelCode3(string serviceLevelCode3, string serviceLevelCode2, bool isValidExpected)
	{
		var subject = new R3_RouteInformationMotor();
		subject.StandardCarrierAlphaCode = "P5";
		subject.RoutingSequenceCode = "K";
		subject.ServiceLevelCode3 = serviceLevelCode3;
		subject.ServiceLevelCode2 = serviceLevelCode2;
		if (serviceLevelCode2 != "")
			subject.ServiceLevelCode = "c5";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
