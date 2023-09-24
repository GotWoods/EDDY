using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RENTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REN*Y*ps*Q*oO*Q*Np*v";

		var expected = new REN_RateRequestInformation()
		{
			RateRequestResponseCode = "Y",
			StandardCarrierAlphaCode = "ps",
			Description = "Q",
			StandardCarrierAlphaCode2 = "oO",
			RateRequestResponseCode2 = "Q",
			StandardCarrierAlphaCode3 = "Np",
			YesNoConditionOrResponseCode = "v",
		};

		var actual = Map.MapObject<REN_RateRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredRateRequestResponseCode(string rateRequestResponseCode, bool isValidExpected)
	{
		var subject = new REN_RateRequestInformation();
		subject.RateRequestResponseCode = rateRequestResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ps", "Q", true)]
	[InlineData("", "Q", false)]
	[InlineData("ps", "", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, string description, bool isValidExpected)
	{
		var subject = new REN_RateRequestInformation();
		subject.RateRequestResponseCode = "Y";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
