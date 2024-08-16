using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class ELMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ELM+y+U+6+r+r+7+v+d+l";

		var expected = new ELM_SimpleDataElementDetails()
		{
			SimpleDataElementTag = "y",
			SimpleDataElementCharacterRepresentationCoded = "U",
			SimpleDataElementLengthTypeCoded = "6",
			SimpleDataElementMaximumLength = "r",
			SimpleDataElementMinimumLength = "r",
			CodeSetIndicatorCoded = "7",
			ClassDesignatorCoded = "v",
			MaintenanceOperationCoded = "d",
			SignificantDigits = "l",
		};

		var actual = Map.MapObject<ELM_SimpleDataElementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredSimpleDataElementTag(string simpleDataElementTag, bool isValidExpected)
	{
		var subject = new ELM_SimpleDataElementDetails();
		//Required fields
		//Test Parameters
		subject.SimpleDataElementTag = simpleDataElementTag;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
