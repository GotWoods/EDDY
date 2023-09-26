using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class UCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UC*m0*i*k*N";

		var expected = new UC_UnderwritingCategory()
		{
			CodeCategory = "m0",
			ReferenceIdentification = "i",
			ReferenceIdentification2 = "k",
			YesNoConditionOrResponseCode = "N",
		};

		var actual = Map.MapObject<UC_UnderwritingCategory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m0", true)]
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
	[InlineData("N", "k", true)]
	[InlineData("N", "", false)]
	[InlineData("", "k", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new UC_UnderwritingCategory();
		//Required fields
		subject.CodeCategory = "m0";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
