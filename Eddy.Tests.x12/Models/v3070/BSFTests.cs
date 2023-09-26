using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class BSFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSF*or*s*v";

		var expected = new BSF_BusinessFunction()
		{
			ClassOfTradeCode = "or",
			CodeListQualifierCode = "s",
			IndustryCode = "v",
		};

		var actual = Map.MapObject<BSF_BusinessFunction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("or", "", true)]
	[InlineData("", "s", true)]
	public void Validation_AtLeastOneClassOfTradeCode(string classOfTradeCode, string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new BSF_BusinessFunction();
		//Required fields
		//Test Parameters
		subject.ClassOfTradeCode = classOfTradeCode;
		subject.CodeListQualifierCode = codeListQualifierCode;
        if (subject.CodeListQualifierCode != "")
            subject.IndustryCode = "or";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("or", "s", false)]
	[InlineData("or", "", true)]
	[InlineData("", "s", true)]
	public void Validation_OnlyOneOfClassOfTradeCode(string classOfTradeCode, string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new BSF_BusinessFunction();
		//Required fields
		//Test Parameters
		subject.ClassOfTradeCode = classOfTradeCode;
		subject.CodeListQualifierCode = codeListQualifierCode;
       
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("s", "v", true)]
	[InlineData("s", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new BSF_BusinessFunction();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		if (subject.CodeListQualifierCode == "")
		   subject.ClassOfTradeCode = "or";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
