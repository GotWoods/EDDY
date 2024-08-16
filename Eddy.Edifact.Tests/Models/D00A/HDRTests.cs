using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class HDRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HDR+g++d+b+g+2";

		var expected = new HDR_HeaderInformation()
		{
			StatusDescriptionCode = "g",
			DateAndTimeInformation = null,
			ReferenceIdentifier = "d",
			FreeTextValue = "b",
			ProductIdentifier = "g",
			LanguageNameCode = "2",
		};

		var actual = Map.MapObject<HDR_HeaderInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
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
		subject.StatusDescriptionCode = "g";
		//Test Parameters
		if (dateAndTimeInformation != "") 
			subject.DateAndTimeInformation = new E013_DateAndTimeInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
