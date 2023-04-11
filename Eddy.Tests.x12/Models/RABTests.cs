using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RABTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAB*wo*7*r*UK*K*R*e*7*w*9";

		var expected = new RAB_RateOrMinimumQualifiers()
		{
			RateValueQualifier = "wo",
			AssignedNumber = 7,
			AlternationPrecedenceCode = "r",
			RateValueQualifier2 = "UK",
			MinimumWeightLogic = "K",
			LoadingRestriction = "R",
			LoadingRestriction2 = "e",
			PercentIntegerFormat = 7,
			UnitConversionFactor = "w",
			AssignedNumber2 = 9,
		};

		var actual = Map.MapObject<RAB_RateOrMinimumQualifiers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", 0, true)]
	[InlineData("K", "UK", 0, true)]
	[InlineData("", "UK", 0, true)]
	[InlineData("K", "", 0, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_MinimumWeightLogic(string minimumWeightLogic, string rateValueQualifier2, int percentIntegerFormat, bool isValidExpected)
	{
		var subject = new RAB_RateOrMinimumQualifiers();
		subject.MinimumWeightLogic = minimumWeightLogic;
		subject.RateValueQualifier2 = rateValueQualifier2;
		if (percentIntegerFormat > 0)
		subject.PercentIntegerFormat = percentIntegerFormat;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
