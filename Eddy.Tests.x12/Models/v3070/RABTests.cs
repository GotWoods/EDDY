using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class RABTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAB*YG*8*w*b6*J*g*d*6*3*9";

		var expected = new RAB_RateOrMinimumQualifiers()
		{
			RateValueQualifier = "YG",
			AssignedNumber = 8,
			AlternationPrecedenceCode = "w",
			RateValueQualifier2 = "b6",
			MinimumWeightLogic = "J",
			LoadingRestriction = "g",
			LoadingRestriction2 = "d",
			Percent = 6,
			UnitConversionFactor = "3",
			AssignedNumber2 = 9,
		};

		var actual = Map.MapObject<RAB_RateOrMinimumQualifiers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b6", "J", true)]
	[InlineData("b6", "", false)]
	[InlineData("", "J", false)]
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
