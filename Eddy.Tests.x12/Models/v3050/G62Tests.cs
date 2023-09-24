using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G62Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G62*6l*jfLrO5*p*deW7*DL*35";

		var expected = new G62_DateTime()
		{
			DateQualifier = "6l",
			Date = "jfLrO5",
			TimeQualifier = "p",
			Time = "deW7",
			TimeCode = "DL",
			Century = 35,
		};

		var actual = Map.MapObject<G62_DateTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6l", "jfLrO5", true)]
	[InlineData("6l", "", false)]
	[InlineData("", "jfLrO5", false)]
	public void Validation_AllAreRequiredDateQualifier(string dateQualifier, string date, bool isValidExpected)
	{
		var subject = new G62_DateTime();
		//Required fields
		//Test Parameters
		subject.DateQualifier = dateQualifier;
		subject.Date = date;

        if (subject.DateQualifier == "")
            subject.TimeQualifier = "AB";

		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "p";
			subject.Time = "deW7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("6l", "p", true)]
	public void Validation_AtLeastOneDateQualifier(string dateQualifier, string timeQualifier, bool isValidExpected)
	{
		var subject = new G62_DateTime();
		//Required fields
		//Test Parameters
		subject.DateQualifier = dateQualifier;
		subject.TimeQualifier = timeQualifier;

        //If one filled, all required
        if (!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "p";
			subject.Time = "deW7";
		}

        if (subject.DateQualifier != "")
            subject.Date = "AAAAAA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "deW7", true)]
	[InlineData("p", "", false)]
	[InlineData("", "deW7", false)]
	public void Validation_AllAreRequiredTimeQualifier(string timeQualifier, string time, bool isValidExpected)
	{
		var subject = new G62_DateTime();
		//Required fields
		//Test Parameters
		subject.TimeQualifier = timeQualifier;
		subject.Time = time;
		//At Least one
		subject.DateQualifier = "6l";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "6l";
			subject.Date = "jfLrO5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
