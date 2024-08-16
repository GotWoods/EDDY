using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class ELVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ELV+O+i+O+h";

		var expected = new ELV_ElementValueDefinition()
		{
			ValueDefinitionCodeQualifier = "O",
			ProcessStageValue = "i",
			RequirementDesignatorCode = "O",
			MaintenanceOperationCode = "h",
		};

		var actual = Map.MapObject<ELV_ElementValueDefinition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredValueDefinitionCodeQualifier(string valueDefinitionCodeQualifier, bool isValidExpected)
	{
		var subject = new ELV_ElementValueDefinition();
		//Required fields
		//Test Parameters
		subject.ValueDefinitionCodeQualifier = valueDefinitionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
