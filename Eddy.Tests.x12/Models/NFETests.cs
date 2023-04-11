using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class NFETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NFE***";

		var expected = new NFE_NutritionFactsPanelProductName()
		{
			CompositeMultipleLanguageTextInformation = null,
			CompositeMultipleLanguageTextInformation2 = null,
			CompositeMultipleLanguageTextInformation3 = null,
		};

		var actual = Map.MapObject<NFE_NutritionFactsPanelProductName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredCompositeMultipleLanguageTextInformation(string compositeMultipleLanguageTextInformation, bool isValidExpected)
	{
		var subject = new NFE_NutritionFactsPanelProductName();
		if (compositeMultipleLanguageTextInformation != "")
		    subject.CompositeMultipleLanguageTextInformation = new C071_CompositeMultipleLanguageTextInformation() { FreeFormMessageText = compositeMultipleLanguageTextInformation };
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
