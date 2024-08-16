using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class SCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SCD+9+++U+J++";

		var expected = new SCD_StructureComponentDefinition()
		{
			ComponentFunctionQualifier = "9",
			StructureComponentIdentification = null,
			PartyIdentificationDetails = null,
			StatusCoded = "U",
			ConfigurationLevel = "J",
			PositionIdentification = null,
			ProductCharacteristic = null,
		};

		var actual = Map.MapObject<SCD_StructureComponentDefinition>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredComponentFunctionQualifier(string componentFunctionQualifier, bool isValidExpected)
	{
		var subject = new SCD_StructureComponentDefinition();
		//Required fields
		//Test Parameters
		subject.ComponentFunctionQualifier = componentFunctionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
