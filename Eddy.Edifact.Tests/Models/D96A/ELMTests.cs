using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class ELMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ELM+T+5+4+V+g+F+h+Z";

		var expected = new ELM_SimpleDataElementDetails()
		{
			SimpleDataElementTag = "T",
			SimpleDataElementCharacterRepresentationCoded = "5",
			SimpleDataElementLengthTypeCoded = "4",
			SimpleDataElementMaximumLength = "V",
			SimpleDataElementMinimumLength = "g",
			CodeSetIndicatorCoded = "F",
			ClassDesignatorCoded = "h",
			MaintenanceOperationCoded = "Z",
		};

		var actual = Map.MapObject<ELM_SimpleDataElementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredSimpleDataElementTag(string simpleDataElementTag, bool isValidExpected)
	{
		var subject = new ELM_SimpleDataElementDetails();
		//Required fields
		//Test Parameters
		subject.SimpleDataElementTag = simpleDataElementTag;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
