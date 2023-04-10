using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CT*D*3*i";

		var expected = new CT_CarType()
		{
			YesNoConditionOrResponseCode = "D",
			CarTypeCode = "3",
			CarTypeCode2 = "i",
		};

		var actual = Map.MapObject<CT_CarType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validatation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CT_CarType();
		subject.CarTypeCode = "3";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validatation_RequiredCarTypeCode(string carTypeCode, bool isValidExpected)
	{
		var subject = new CT_CarType();
		subject.YesNoConditionOrResponseCode = "D";
		subject.CarTypeCode = carTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
