using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class ELMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ELM+i+d+r+q+d+y+9+Z+K";

		var expected = new ELM_SimpleDataElementDetails()
		{
			SimpleDataElementTagIdentifier = "i",
			SimpleDataElementCharacterRepresentationCode = "d",
			LengthTypeCode = "r",
			SimpleDataElementMaximumLengthValue = "q",
			SimpleDataElementMinimumLengthValue = "d",
			CodeSetIndicatorCode = "y",
			DesignatedClassCode = "9",
			MaintenanceOperationCode = "Z",
			SignificantDigitsQuantity = "K",
		};

		var actual = Map.MapObject<ELM_SimpleDataElementDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredSimpleDataElementTagIdentifier(string simpleDataElementTagIdentifier, bool isValidExpected)
	{
		var subject = new ELM_SimpleDataElementDetails();
		//Required fields
		//Test Parameters
		subject.SimpleDataElementTagIdentifier = simpleDataElementTagIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
