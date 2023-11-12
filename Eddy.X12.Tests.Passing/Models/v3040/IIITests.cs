using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class IIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "III*D*n*xT*c";

		var expected = new III_Information()
		{
			CodeListQualifierCode = "D",
			IndustryCode = "n",
			CodeCategory = "xT",
			FreeFormMessageText = "c",
		};

		var actual = Map.MapObject<III_Information>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("D", "n", true)]
	[InlineData("D", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new III_Information();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeCategory) || !string.IsNullOrEmpty(subject.CodeCategory) || !string.IsNullOrEmpty(subject.FreeFormMessageText))
		{
			subject.CodeCategory = "xT";
			subject.FreeFormMessageText = "c";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xT", "c", true)]
	[InlineData("xT", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredCodeCategory(string codeCategory, string freeFormMessageText, bool isValidExpected)
	{
		var subject = new III_Information();
		//Required fields
		//Test Parameters
		subject.CodeCategory = codeCategory;
		subject.FreeFormMessageText = freeFormMessageText;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "D";
			subject.IndustryCode = "n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
