using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CT*Q*q*Z";

		var expected = new CT_CarType()
		{
			YesNoConditionOrResponseCode = "Q",
			CarTypeCode = "q",
			CarTypeCode2 = "Z",
		};

		var actual = Map.MapObject<CT_CarType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CT_CarType();
		//Required fields
		subject.CarTypeCode = "q";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredCarTypeCode(string carTypeCode, bool isValidExpected)
	{
		var subject = new CT_CarType();
		//Required fields
		subject.YesNoConditionOrResponseCode = "Q";
		//Test Parameters
		subject.CarTypeCode = carTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
