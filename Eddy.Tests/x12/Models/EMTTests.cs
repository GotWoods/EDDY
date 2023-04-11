using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class EMTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EMT*L*J*XO*YS*f*f*d*c";

		var expected = new EMT_Employment()
		{
			CodeListQualifierCode = "L",
			IndustryCode = "J",
			StateOrProvinceCode = "XO",
			IdentificationCode = "YS",
			Description = "f",
			YesNoConditionOrResponseCode = "f",
			YesNoConditionOrResponseCode2 = "d",
			YesNoConditionOrResponseCode3 = "c",
		};

		var actual = Map.MapObject<EMT_Employment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("L", "J", true)]
	[InlineData("", "J", false)]
	[InlineData("L", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new EMT_Employment();
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
