using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class SCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SCD+i+++I+g++";

		var expected = new SCD_StructureComponentDefinition()
		{
			StructureComponentFunctionCodeQualifier = "i",
			StructureComponentIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "I",
			ConfigurationLevelNumber = "g",
			PositionIdentification = null,
			ProductCharacteristic = null,
		};

		var actual = Map.MapObject<SCD_StructureComponentDefinition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredStructureComponentFunctionCodeQualifier(string structureComponentFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new SCD_StructureComponentDefinition();
		//Required fields
		//Test Parameters
		subject.StructureComponentFunctionCodeQualifier = structureComponentFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
