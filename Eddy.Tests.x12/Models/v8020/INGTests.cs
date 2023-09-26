using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class INGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ING*1**3*o*B*w";

		var expected = new ING_Ingredients()
		{
			AssignedIdentification = "1",
			CompositeIngredientInformation = null,
			PercentDecimalFormat = 3,
			YesNoConditionOrResponseCode = "o",
			YesNoConditionOrResponseCode2 = "B",
			YesNoConditionOrResponseCode3 = "w",
		};

		var actual = Map.MapObject<ING_Ingredients>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
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
		subject.AssignedIdentification = "1";
		//Test Parameters
		if (compositeIngredientInformation != "") 
			subject.CompositeIngredientInformation = new C068_CompositeIngredientInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
