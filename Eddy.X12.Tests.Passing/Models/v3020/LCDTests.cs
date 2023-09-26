using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LCD*P*IH*X*46XTww*a*2a";

		var expected = new LCD_PlaceLocationDescription()
		{
			AssignedIdentification = "P",
			EntityIdentifierCode = "IH",
			ActionCode = "X",
			Date = "46XTww",
			IdentificationCodeQualifier = "a",
			IdentificationCode = "2a",
		};

		var actual = Map.MapObject<LCD_PlaceLocationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new LCD_PlaceLocationDescription();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "a";
			subject.IdentificationCode = "2a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "2a", true)]
	[InlineData("a", "", false)]
	[InlineData("", "2a", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new LCD_PlaceLocationDescription();
		//Required fields
		subject.AssignedIdentification = "P";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
