using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class INGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ING*p**7*8*F";

		var expected = new ING_Ingredients()
		{
			AssignedIdentification = "p",
			CompositeIngredientInformation = null,
			PercentDecimalFormat = 7,
			YesNoConditionOrResponseCode = "8",
			YesNoConditionOrResponseCode2 = "F",
		};

		var actual = Map.MapObject<ING_Ingredients>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new ING_Ingredients();
		//Required fields
		subject.CompositeIngredientInformation = new C068_CompositeIngredientInformation();
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeIngredientInformation(string compositeIngredientInformation, bool isValidExpected)
	{
		var subject = new ING_Ingredients();
		//Required fields
		subject.AssignedIdentification = "p";
		//Test Parameters
		if (compositeIngredientInformation != "") 
			subject.CompositeIngredientInformation = new C068_CompositeIngredientInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
