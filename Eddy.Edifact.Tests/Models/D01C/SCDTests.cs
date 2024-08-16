using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class SCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SCD+7+++P+G++";

		var expected = new SCD_StructureComponentDefinition()
		{
			StructureComponentFunctionCodeQualifier = "7",
			StructureComponentIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "P",
			ConfigurationLevelNumber = "G",
			PositionIdentification = null,
			CharacteristicDescription = null,
		};

		var actual = Map.MapObject<SCD_StructureComponentDefinition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredStructureComponentFunctionCodeQualifier(string structureComponentFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new SCD_StructureComponentDefinition();
		//Required fields
		//Test Parameters
		subject.StructureComponentFunctionCodeQualifier = structureComponentFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
