using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CDVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CDV+x+D+8+f+A";

		var expected = new CDV_CodeValueDefinition()
		{
			CodeValue = "x",
			CodeName = "D",
			MaintenanceOperationCode = "8",
			CodeValueSourceCode = "f",
			RequirementDesignatorCode = "A",
		};

		var actual = Map.MapObject<CDV_CodeValueDefinition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredCodeValue(string codeValue, bool isValidExpected)
	{
		var subject = new CDV_CodeValueDefinition();
		//Required fields
		//Test Parameters
		subject.CodeValue = codeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
