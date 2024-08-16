using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class CDVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CDV+5+D+8+H+I";

		var expected = new CDV_CodeValueDefinition()
		{
			CodeValueText = "5",
			CodeName = "D",
			MaintenanceOperationCode = "8",
			CodeValueSourceCode = "H",
			RequirementDesignatorCode = "I",
		};

		var actual = Map.MapObject<CDV_CodeValueDefinition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredCodeValueText(string codeValueText, bool isValidExpected)
	{
		var subject = new CDV_CodeValueDefinition();
		//Required fields
		//Test Parameters
		subject.CodeValueText = codeValueText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
