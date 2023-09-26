using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class LCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LCD*y*SW*W*T2cpGJXf*H*29";

		var expected = new LCD_PlaceLocationDescription()
		{
			AssignedIdentification = "y",
			EntityIdentifierCode = "SW",
			ActionCode = "W",
			Date = "T2cpGJXf",
			IdentificationCodeQualifier = "H",
			IdentificationCode = "29",
		};

		var actual = Map.MapObject<LCD_PlaceLocationDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "29", true)]
	[InlineData("H", "", false)]
	[InlineData("", "29", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new LCD_PlaceLocationDescription();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
