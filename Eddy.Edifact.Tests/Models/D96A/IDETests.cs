using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class IDETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "IDE+j+++5+r++";

		var expected = new IDE_Identity()
		{
			IdentificationQualifier = "j",
			IdentificationNumber = null,
			PartyIdentificationDetails = null,
			StatusCoded = "5",
			ConfigurationLevel = "r",
			PositionIdentification = null,
			ProductCharacteristic = null,
		};

		var actual = Map.MapObject<IDE_Identity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredIdentificationQualifier(string identificationQualifier, bool isValidExpected)
	{
		var subject = new IDE_Identity();
		//Required fields
		subject.IdentificationNumber = new C206_IdentificationNumber();
		//Test Parameters
		subject.IdentificationQualifier = identificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredIdentificationNumber(string identificationNumber, bool isValidExpected)
	{
		var subject = new IDE_Identity();
		//Required fields
		subject.IdentificationQualifier = "j";
		//Test Parameters
		if (identificationNumber != "") 
			subject.IdentificationNumber = new C206_IdentificationNumber();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
