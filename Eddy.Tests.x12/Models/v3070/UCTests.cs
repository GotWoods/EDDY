using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class UCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UC*hG*U*A*q";

		var expected = new UC_UnderwritingCategory()
		{
			CodeCategory = "hG",
			ReferenceIdentification = "U",
			ReferenceIdentification2 = "A",
			YesNoConditionOrResponseCode = "q",
		};

		var actual = Map.MapObject<UC_UnderwritingCategory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hG", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new UC_UnderwritingCategory();
		//Required fields
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "A", true)]
	[InlineData("q", "", false)]
	[InlineData("", "A", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new UC_UnderwritingCategory();
		//Required fields
		subject.CodeCategory = "hG";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
