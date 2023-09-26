using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.Tests.Models.v8030;

public class ALGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ALG*X*q*m*L*E8";

		var expected = new ALG_Allergen()
		{
			AssignedIdentification = "X",
			AllergenTypeCode = "q",
			YesNoConditionOrResponseCode = "m",
			Description = "L",
			ConditionIndicatorCode = "E8",
		};

		var actual = Map.MapObject<ALG_Allergen>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
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
		subject.AllergenTypeCode = "q";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
