using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class INGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ING*i**7*y*Z*e";

		var expected = new ING_Ingredients()
		{
			AssignedIdentification = "i",
			CompositeIngredientInformation = "",
			PercentDecimalFormat = 7,
			YesNoConditionOrResponseCode = "y",
			YesNoConditionOrResponseCode2 = "Z",
			YesNoConditionOrResponseCode3 = "e",
		};

		var actual = Map.MapObject<ING_Ingredients>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new ING_Ingredients();
		subject.CompositeIngredientInformation = "";
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("", true)]
	public void Validation_RequiredCompositeIngredientInformation(C068_CompositeIngredientInformation compositeIngredientInformation, bool isValidExpected)
	{
		var subject = new ING_Ingredients();
		subject.AssignedIdentification = "i";
		subject.CompositeIngredientInformation = compositeIngredientInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
