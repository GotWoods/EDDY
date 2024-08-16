using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class SCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SCD+u+++A+B++";

		var expected = new SCD_StructureComponentDefinition()
		{
			StructureComponentFunctionCodeQualifier = "u",
			StructureComponentIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "A",
			ConfigurationLevel = "B",
			PositionIdentification = null,
			ProductCharacteristic = null,
		};

		var actual = Map.MapObject<SCD_StructureComponentDefinition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredStructureComponentFunctionCodeQualifier(string structureComponentFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new SCD_StructureComponentDefinition();
		//Required fields
		//Test Parameters
		subject.StructureComponentFunctionCodeQualifier = structureComponentFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
