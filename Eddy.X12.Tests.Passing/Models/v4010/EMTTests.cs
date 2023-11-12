using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class EMTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EMT*O*c*sB*RB*l*B*x*U";

		var expected = new EMT_Employment()
		{
			CodeListQualifierCode = "O",
			IndustryCode = "c",
			StateOrProvinceCode = "sB",
			IdentificationCode = "RB",
			Description = "l",
			YesNoConditionOrResponseCode = "B",
			YesNoConditionOrResponseCode2 = "x",
			YesNoConditionOrResponseCode3 = "U",
		};

		var actual = Map.MapObject<EMT_Employment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("O", "c", true)]
	[InlineData("O", "", false)]
	[InlineData("", "c", false)]
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
