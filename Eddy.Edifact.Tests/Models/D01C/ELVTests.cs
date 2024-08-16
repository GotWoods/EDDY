using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class ELVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ELV+l+d+g+q";

		var expected = new ELV_ElementValueDefinition()
		{
			ValueDefinitionCodeQualifier = "l",
			ValueText = "d",
			RequirementDesignatorCode = "g",
			MaintenanceOperationCode = "q",
		};

		var actual = Map.MapObject<ELV_ElementValueDefinition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredValueDefinitionCodeQualifier(string valueDefinitionCodeQualifier, bool isValidExpected)
	{
		var subject = new ELV_ElementValueDefinition();
		//Required fields
		//Test Parameters
		subject.ValueDefinitionCodeQualifier = valueDefinitionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
