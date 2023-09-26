using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class LCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LCD*p*9g*B*WsxL95*f*1c";

		var expected = new LCD_PlaceLocationDescription()
		{
			AssignedIdentification = "p",
			EntityIdentifierCode = "9g",
			ActionCode = "B",
			Date = "WsxL95",
			IdentificationCodeQualifier = "f",
			IdentificationCode = "1c",
		};

		var actual = Map.MapObject<LCD_PlaceLocationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new LCD_PlaceLocationDescription();
		//Required fields
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "f";
			subject.IdentificationCode = "1c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "1c", true)]
	[InlineData("f", "", false)]
	[InlineData("", "1c", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new LCD_PlaceLocationDescription();
		//Required fields
		subject.AssignedIdentification = "p";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
