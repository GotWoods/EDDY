using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class HDRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HDR+s++8+C+I+5";

		var expected = new HDR_HeaderInformation()
		{
			StatusDescriptionCode = "s",
			DateAndTimeInformation = null,
			ReferenceIdentifier = "8",
			FreeText = "C",
			ProductIdentifier = "I",
			LanguageNameCode = "5",
		};

		var actual = Map.MapObject<HDR_HeaderInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredStatusDescriptionCode(string statusDescriptionCode, bool isValidExpected)
	{
		var subject = new HDR_HeaderInformation();
		//Required fields
		subject.DateAndTimeInformation = new E013_DateAndTimeInformation();
		//Test Parameters
		subject.StatusDescriptionCode = statusDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDateAndTimeInformation(string dateAndTimeInformation, bool isValidExpected)
	{
		var subject = new HDR_HeaderInformation();
		//Required fields
		subject.StatusDescriptionCode = "s";
		//Test Parameters
		if (dateAndTimeInformation != "") 
			subject.DateAndTimeInformation = new E013_DateAndTimeInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
