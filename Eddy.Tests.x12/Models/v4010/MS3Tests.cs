using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class MS3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS3*6h*q*Jz*k*Jn";

		var expected = new MS3_InterlineInformation()
		{
			StandardCarrierAlphaCode = "6h",
			RoutingSequenceCode = "q",
			CityName = "Jz",
			TransportationMethodTypeCode = "k",
			StateOrProvinceCode = "Jn",
		};

		var actual = Map.MapObject<MS3_InterlineInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6h", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new MS3_InterlineInformation();
		//Required fields
		subject.RoutingSequenceCode = "q";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
	{
		var subject = new MS3_InterlineInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "6h";
		//Test Parameters
		subject.RoutingSequenceCode = routingSequenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Jn", "Jz", true)]
	[InlineData("Jn", "", false)]
	[InlineData("", "Jz", true)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new MS3_InterlineInformation();
		//Required fields
		subject.StandardCarrierAlphaCode = "6h";
		subject.RoutingSequenceCode = "q";
		//Test Parameters
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
