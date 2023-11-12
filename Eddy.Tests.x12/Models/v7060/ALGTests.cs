using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class ALGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ALG*g*e*m*8*vE";

		var expected = new ALG_Allergen()
		{
			AssignedIdentification = "g",
			AllergenTypeCode = "e",
			YesNoConditionOrResponseCode = "m",
			Description = "8",
			ConditionIndicatorCode = "vE",
		};

		var actual = Map.MapObject<ALG_Allergen>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredAllergenTypeCode(string allergenTypeCode, bool isValidExpected)
	{
		var subject = new ALG_Allergen();
		//Required fields
		subject.YesNoConditionOrResponseCode = "m";
		//Test Parameters
		subject.AllergenTypeCode = allergenTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new ALG_Allergen();
		//Required fields
		subject.AllergenTypeCode = "e";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]

	[InlineData("m", "8", false)]
	[InlineData("m", "", true)]
	public void Validation_OnlyOneOfYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string description, bool isValidExpected)
	{
		var subject = new ALG_Allergen();
		//Required fields
		subject.AllergenTypeCode = "e";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
