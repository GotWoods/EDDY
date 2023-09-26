using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class RENTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REN*4*7e*E*AU*I*N2*B";

		var expected = new REN_RateRequestInformation()
		{
			RateRequestResponseCode = "4",
			StandardCarrierAlphaCode = "7e",
			Description = "E",
			StandardCarrierAlphaCode2 = "AU",
			RateRequestResponseCode2 = "I",
			StandardCarrierAlphaCode3 = "N2",
			YesNoConditionOrResponseCode = "B",
		};

		var actual = Map.MapObject<REN_RateRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredRateRequestResponseCode(string rateRequestResponseCode, bool isValidExpected)
	{
		var subject = new REN_RateRequestInformation();
		//Required fields
		//Test Parameters
		subject.RateRequestResponseCode = rateRequestResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.Description))
		{
			subject.StandardCarrierAlphaCode = "7e";
			subject.Description = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("7e", "E", true)]
	[InlineData("7e", "", false)]
	[InlineData("", "E", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, string description, bool isValidExpected)
	{
		var subject = new REN_RateRequestInformation();
		//Required fields
		subject.RateRequestResponseCode = "4";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
