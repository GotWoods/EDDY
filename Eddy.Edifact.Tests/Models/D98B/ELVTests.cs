using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class ELVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ELV+6+6+h+y";

		var expected = new ELV_ElementValueDefinition()
		{
			ValueDefinitionQualifier = "6",
			Value = "6",
			RequirementDesignatorCoded = "h",
			MaintenanceOperationCoded = "y",
		};

		var actual = Map.MapObject<ELV_ElementValueDefinition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredValueDefinitionQualifier(string valueDefinitionQualifier, bool isValidExpected)
	{
		var subject = new ELV_ElementValueDefinition();
		//Required fields
		//Test Parameters
		subject.ValueDefinitionQualifier = valueDefinitionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
