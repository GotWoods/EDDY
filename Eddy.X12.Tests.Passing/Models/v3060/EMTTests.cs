using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class EMTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EMT*w*z*0n*uC*X*h*S*g";

		var expected = new EMT_Employment()
		{
			CodeListQualifierCode = "w",
			IndustryCode = "z",
			StateOrProvinceCode = "0n",
			IdentificationCode = "uC",
			Description = "X",
			YesNoConditionOrResponseCode = "h",
			YesNoConditionOrResponseCode2 = "S",
			YesNoConditionOrResponseCode3 = "g",
		};

		var actual = Map.MapObject<EMT_Employment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "z", true)]
	[InlineData("w", "", false)]
	[InlineData("", "z", false)]
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
