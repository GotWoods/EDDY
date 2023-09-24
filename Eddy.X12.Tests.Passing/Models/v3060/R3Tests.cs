using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class R3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R3*Xy*K*cj*t*TznGgu*6*SXBQVE*X*O*1D*Ns*Sj";

		var expected = new R3_RouteInformationMotor()
		{
			StandardCarrierAlphaCode = "Xy",
			RoutingSequenceCode = "K",
			CityName = "cj",
			TransportationMethodTypeCode = "t",
			StandardPointLocationCode = "TznGgu",
			InvoiceNumber = "6",
			Date = "SXBQVE",
			Amount = "X",
			FreeFormDescription = "O",
			ServiceLevelCode = "1D",
			ServiceLevelCode2 = "Ns",
			ServiceLevelCode3 = "Sj",
		};

		var actual = Map.MapObject<R3_RouteInformationMotor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xy", true)]
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
		subject.StandardCarrierAlphaCode = "Xy";
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ns", "1D", true)]
	[InlineData("Ns", "", false)]
	[InlineData("", "1D", true)]
	public void Validation_ARequiresBServiceLevelCode2(string serviceLevelCode2, string serviceLevelCode, bool isValidExpected)
	{
		var subject = new R3_RouteInformationMotor();
		subject.StandardCarrierAlphaCode = "Xy";
		subject.RoutingSequenceCode = "K";
		subject.ServiceLevelCode2 = serviceLevelCode2;
		subject.ServiceLevelCode = serviceLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Sj", "Ns", true)]
	[InlineData("Sj", "", false)]
	[InlineData("", "Ns", true)]
	public void Validation_ARequiresBServiceLevelCode3(string serviceLevelCode3, string serviceLevelCode2, bool isValidExpected)
	{
		var subject = new R3_RouteInformationMotor();
		subject.StandardCarrierAlphaCode = "Xy";
		subject.RoutingSequenceCode = "K";
		subject.ServiceLevelCode3 = serviceLevelCode3;
		subject.ServiceLevelCode2 = serviceLevelCode2;
		if (serviceLevelCode2 != "")
			subject.ServiceLevelCode = "1D";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
