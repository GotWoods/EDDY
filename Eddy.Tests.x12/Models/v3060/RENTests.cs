using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class RENTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REN*O*zG*y*S3*x*5I*I";

		var expected = new REN_RateRequestInformation()
		{
			RateRequestResponseCode = "O",
			StandardCarrierAlphaCode = "zG",
			ReferenceIdentification = "y",
			StandardCarrierAlphaCode2 = "S3",
			RateRequestResponseCode2 = "x",
			StandardCarrierAlphaCode3 = "5I",
			YesNoConditionOrResponseCode = "I",
		};

		var actual = Map.MapObject<REN_RateRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredRateRequestResponseCode(string rateRequestResponseCode, bool isValidExpected)
	{
		var subject = new REN_RateRequestInformation();
		//Required fields
		//Test Parameters
		subject.RateRequestResponseCode = rateRequestResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.StandardCarrierAlphaCode = "zG";
			subject.ReferenceIdentification = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zG", "y", true)]
	[InlineData("zG", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, string referenceIdentification, bool isValidExpected)
	{
		var subject = new REN_RateRequestInformation();
		//Required fields
		subject.RateRequestResponseCode = "O";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
