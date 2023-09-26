using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class LCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LCD*A*y3*S*tQAUfS*A*KK";

		var expected = new LCD_PlaceLocationDescription()
		{
			AssignedIdentification = "A",
			EntityIdentifierCode = "y3",
			ActionCode = "S",
			Date = "tQAUfS",
			IdentificationCodeQualifier = "A",
			IdentificationCode = "KK",
		};

		var actual = Map.MapObject<LCD_PlaceLocationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new LCD_PlaceLocationDescription();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "A";
			subject.IdentificationCode = "KK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "KK", true)]
	[InlineData("A", "", false)]
	[InlineData("", "KK", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new LCD_PlaceLocationDescription();
		//Required fields
		subject.AssignedIdentification = "A";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
