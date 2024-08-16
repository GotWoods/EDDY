using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B;

public class ELVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ELV+M+e+E+Y";

		var expected = new ELV_ElementValueDefinition()
		{
			ValueDefinitionCodeQualifier = "M",
			Value = "e",
			RequirementDesignatorCode = "E",
			MaintenanceOperationCode = "Y",
		};

		var actual = Map.MapObject<ELV_ElementValueDefinition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredValueDefinitionCodeQualifier(string valueDefinitionCodeQualifier, bool isValidExpected)
	{
		var subject = new ELV_ElementValueDefinition();
		//Required fields
		//Test Parameters
		subject.ValueDefinitionCodeQualifier = valueDefinitionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
