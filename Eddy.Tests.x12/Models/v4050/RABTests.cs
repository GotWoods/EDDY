using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class RABTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAB*0K*1*I*Q7*k*Z*j*9*C*9";

		var expected = new RAB_RateOrMinimumQualifiers()
		{
			RateValueQualifier = "0K",
			AssignedNumber = 1,
			AlternationPrecedenceCode = "I",
			RateValueQualifier2 = "Q7",
			MinimumWeightLogic = "k",
			LoadingRestriction = "Z",
			LoadingRestriction2 = "j",
			PercentIntegerFormat = 9,
			UnitConversionFactor = "C",
			AssignedNumber2 = 9,
		};

		var actual = Map.MapObject<RAB_RateOrMinimumQualifiers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q7", "k", true)]
	[InlineData("Q7", "", false)]
	[InlineData("", "k", false)]
	public void Validation_AllAreRequiredRateValueQualifier2(string rateValueQualifier2, string minimumWeightLogic, bool isValidExpected)
	{
		var subject = new RAB_RateOrMinimumQualifiers();
		//Required fields
		//Test Parameters
		subject.RateValueQualifier2 = rateValueQualifier2;
		subject.MinimumWeightLogic = minimumWeightLogic;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
