using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class IDETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IDE+t+++P+E++";

		var expected = new IDE_Identity()
		{
			ObjectTypeCodeQualifier = "t",
			IdentificationNumber = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "P",
			ConfigurationLevelNumber = "E",
			PositionIdentification = null,
			CharacteristicDescription = null,
		};

		var actual = Map.MapObject<IDE_Identity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredObjectTypeCodeQualifier(string objectTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new IDE_Identity();
		//Required fields
		//Test Parameters
		subject.ObjectTypeCodeQualifier = objectTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
