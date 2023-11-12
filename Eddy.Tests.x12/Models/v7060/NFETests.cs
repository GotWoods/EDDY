using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7060.Composites;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

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
	[InlineData("A", true)]
	public void Validation_RequiredCompositeMultipleLanguageTextInformation(string compositeMultipleLanguageTextInformation, bool isValidExpected)
	{
		var subject = new NFE_NutritionFactsPanelProductName();
		//Required fields
		//Test Parameters
		if (compositeMultipleLanguageTextInformation != "") 
			subject.CompositeMultipleLanguageTextInformation = new C071_CompositeMultipleLanguageTextInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
