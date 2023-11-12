using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class RABTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RAB*Af*4*F*88*X*J*d*9*k*3";

		var expected = new RAB_RateOrMinimumQualifiers()
		{
			RateValueQualifier = "Af",
			AssignedNumber = 4,
			AlternationPrecedenceCode = "F",
			RateValueQualifier2 = "88",
			MinimumWeightLogic = "X",
			LoadingRestriction = "J",
			LoadingRestriction2 = "d",
			PercentIntegerFormat = 9,
			UnitConversionFactor = "k",
			AssignedNumber2 = 3,
		};

		var actual = Map.MapObject<RAB_RateOrMinimumQualifiers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", 0, true)]
	[InlineData("X", "88", 9, true)]
	[InlineData("X", "", 0, false)]
	[InlineData("", "88", 9, true)]
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
