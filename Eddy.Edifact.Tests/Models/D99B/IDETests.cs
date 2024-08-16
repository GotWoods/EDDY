using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class IDETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IDE+G+++U+R++";

		var expected = new IDE_Identity()
		{
			ObjectTypeCodeQualifier = "G",
			IdentificationNumber = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "U",
			ConfigurationLevel = "R",
			PositionIdentification = null,
			ProductCharacteristic = null,
		};

		var actual = Map.MapObject<IDE_Identity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredObjectTypeCodeQualifier(string objectTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new IDE_Identity();
		//Required fields
		//Test Parameters
		subject.ObjectTypeCodeQualifier = objectTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
