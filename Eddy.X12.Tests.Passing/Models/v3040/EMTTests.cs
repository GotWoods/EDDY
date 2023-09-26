using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class EMTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EMT*V*f*Sf*pV*b*e*p*c";

		var expected = new EMT_Employment()
		{
			CodeListQualifierCode = "V",
			IndustryCode = "f",
			StateOrProvinceCode = "Sf",
			IdentificationCode = "pV",
			Description = "b",
			YesNoConditionOrResponseCode = "e",
			YesNoConditionOrResponseCode2 = "p",
			YesNoConditionOrResponseCode3 = "c",
		};

		var actual = Map.MapObject<EMT_Employment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "f", true)]
	[InlineData("V", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new EMT_Employment();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
