using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class IDETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IDE+H+++M+x++";

		var expected = new IDE_Identity()
		{
			ObjectTypeCodeQualifier = "H",
			IdentificationNumber = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "M",
			ConfigurationLevelNumber = "x",
			PositionIdentification = null,
			ProductCharacteristic = null,
		};

		var actual = Map.MapObject<IDE_Identity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredObjectTypeCodeQualifier(string objectTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new IDE_Identity();
		//Required fields
		//Test Parameters
		subject.ObjectTypeCodeQualifier = objectTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
