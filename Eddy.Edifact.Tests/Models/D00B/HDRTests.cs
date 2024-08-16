using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B;

public class HDRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "HDR+j++N+1+b+C";

		var expected = new HDR_HeaderInformation()
		{
			StatusDescriptionCode = "j",
			DateAndTimeInformation = null,
			ReferenceIdentifier = "N",
			FreeTextValue = "1",
			ProductIdentifier = "b",
			LanguageNameCode = "C",
		};

		var actual = Map.MapObject<HDR_HeaderInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
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
		subject.StatusDescriptionCode = "j";
		//Test Parameters
		if (dateAndTimeInformation != "") 
			subject.DateAndTimeInformation = new E013_DateAndTimeInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
