using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class RABTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAB*sn*5*R*dr*e*g*Z*3*v*2";

		var expected = new RAB_RateOrMinimumQualifiers()
		{
			RateValueQualifier = "sn",
			AssignedNumber = 5,
			AlternationPrecedenceCode = "R",
			RateValueQualifier2 = "dr",
			MinimumWeightLogic = "e",
			LoadingRestriction = "g",
			LoadingRestriction2 = "Z",
			PercentIntegerFormat = 3,
			UnitConversionFactor = "v",
			AssignedNumber2 = 2,
		};

		var actual = Map.MapObject<RAB_RateOrMinimumQualifiers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("e", "dr", 3, true)]
	[InlineData("e", "", 0, false)]
	[InlineData("", "dr", 3, true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_MinimumWeightLogic(string minimumWeightLogic, string rateValueQualifier2, int percentIntegerFormat, bool isValidExpected)
	{
		var subject = new RAB_RateOrMinimumQualifiers();
		//Required fields
		//Test Parameters
		subject.MinimumWeightLogic = minimumWeightLogic;
		subject.RateValueQualifier2 = rateValueQualifier2;
		if (percentIntegerFormat > 0) 
			subject.PercentIntegerFormat = percentIntegerFormat;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
