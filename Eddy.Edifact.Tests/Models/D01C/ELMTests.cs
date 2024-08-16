using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class ELMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ELM+e+G+7+5+7+r+E+U+I";

		var expected = new ELM_SimpleDataElementDetails()
		{
			SimpleDataElementTagIdentifier = "e",
			SimpleDataElementCharacterRepresentationCode = "G",
			LengthTypeCode = "7",
			SimpleDataElementMaximumLengthMeasure = "5",
			SimpleDataElementMinimumLengthMeasure = "7",
			CodeSetIndicatorCode = "r",
			DesignatedClassCode = "E",
			MaintenanceOperationCode = "U",
			SignificantDigitsQuantity = "I",
		};

		var actual = Map.MapObject<ELM_SimpleDataElementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredSimpleDataElementTagIdentifier(string simpleDataElementTagIdentifier, bool isValidExpected)
	{
		var subject = new ELM_SimpleDataElementDetails();
		//Required fields
		//Test Parameters
		subject.SimpleDataElementTagIdentifier = simpleDataElementTagIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
