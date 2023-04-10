using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BSFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSF*yU";

		var expected = new BSF_BusinessFunction()
		{
			ClassOfTradeCode = "yU",
			//CodeListQualifierCode = "h",
			//IndustryCode = "F",
		};

		var actual = Map.MapObject<BSF_BusinessFunction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("yU","", true)]
	[InlineData("", "h", true)]
	public void Validation_AtLeastOneClassOfTradeCode(string classOfTradeCode, string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new BSF_BusinessFunction();
		subject.ClassOfTradeCode = classOfTradeCode;
		subject.CodeListQualifierCode = codeListQualifierCode;
		if (codeListQualifierCode != "")
			subject.IndustryCode = "12";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("yU", "h", false)]
	[InlineData("", "h", true)]
	[InlineData("yU", "", true)]
	public void Validation_OnlyOneOfClassOfTradeCode(string classOfTradeCode, string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new BSF_BusinessFunction();
		subject.ClassOfTradeCode = classOfTradeCode;
		subject.CodeListQualifierCode = codeListQualifierCode;
        if (codeListQualifierCode != "")
            subject.IndustryCode = "12";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("h", "F", true)]
	[InlineData("", "F", false)]
	[InlineData("h", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new BSF_BusinessFunction();
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		if (subject.CodeListQualifierCode == "")
		    subject.ClassOfTradeCode = "AB";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
