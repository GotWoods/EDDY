using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class UCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UC*xL*Y*w*v";

		var expected = new UC_UnderwritingCategory()
		{
			CodeCategory = "xL",
			ReferenceIdentification = "Y",
			ReferenceIdentification2 = "w",
			YesNoConditionOrResponseCode = "v",
		};

		var actual = Map.MapObject<UC_UnderwritingCategory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xL", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new UC_UnderwritingCategory();
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "w", true)]
	[InlineData("v", "", false)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new UC_UnderwritingCategory();
		subject.CodeCategory = "xL";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
