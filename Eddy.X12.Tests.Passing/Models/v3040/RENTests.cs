using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class RENTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REN*z*ta*A*lw*n*GN*9";

		var expected = new REN_RateRequestInformation()
		{
			RateRequestResponseCode = "z",
			StandardCarrierAlphaCode = "ta",
			ReferenceNumber = "A",
			StandardCarrierAlphaCode2 = "lw",
			RateRequestResponseCode2 = "n",
			StandardCarrierAlphaCode3 = "GN",
			YesNoConditionOrResponseCode = "9",
		};

		var actual = Map.MapObject<REN_RateRequestInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredRateRequestResponseCode(string rateRequestResponseCode, bool isValidExpected)
	{
		var subject = new REN_RateRequestInformation();
		//Required fields
		//Test Parameters
		subject.RateRequestResponseCode = rateRequestResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.StandardCarrierAlphaCode) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.StandardCarrierAlphaCode = "ta";
			subject.ReferenceNumber = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ta", "A", true)]
	[InlineData("ta", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, string referenceNumber, bool isValidExpected)
	{
		var subject = new REN_RateRequestInformation();
		//Required fields
		subject.RateRequestResponseCode = "z";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
