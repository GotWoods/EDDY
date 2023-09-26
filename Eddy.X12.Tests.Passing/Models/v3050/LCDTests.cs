using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class LCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LCD*i*n5*e*tpUjBg*p*CI";

		var expected = new LCD_PlaceLocationDescription()
		{
			AssignedIdentification = "i",
			EntityIdentifierCode = "n5",
			ActionCode = "e",
			Date = "tpUjBg",
			IdentificationCodeQualifier = "p",
			IdentificationCode = "CI",
		};

		var actual = Map.MapObject<LCD_PlaceLocationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new LCD_PlaceLocationDescription();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "p";
			subject.IdentificationCode = "CI";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "CI", true)]
	[InlineData("p", "", false)]
	[InlineData("", "CI", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new LCD_PlaceLocationDescription();
		//Required fields
		subject.AssignedIdentification = "i";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
