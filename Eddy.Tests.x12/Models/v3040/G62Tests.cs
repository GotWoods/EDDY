using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class G62Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G62*al*BUdul2*f*c2cj*6y*44";

		var expected = new G62_DateTime()
		{
			DateQualifier = "al",
			Date = "BUdul2",
			TimeQualifier = "f",
			Time = "c2cj",
			TimeCode = "6y",
			Century = 44,
		};

		var actual = Map.MapObject<G62_DateTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("al", "BUdul2", true)]
	[InlineData("al", "", false)]
	[InlineData("", "BUdul2", false)]
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
        if (!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "f";
			subject.Time = "c2cj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("al", "f", true)]
	[InlineData("al", "", true)]
	[InlineData("", "f", true)]
	public void Validation_AtLeastOneDateQualifier(string dateQualifier, string timeQualifier, bool isValidExpected)
	{
		var subject = new G62_DateTime();
		//Required fields
		//Test Parameters
		subject.DateQualifier = dateQualifier;
		subject.TimeQualifier = timeQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.TimeQualifier) || !string.IsNullOrEmpty(subject.Time))
		{
			subject.TimeQualifier = "f";
			subject.Time = "c2cj";
		}

        if (subject.DateQualifier != "")
            subject.Date = "AAAAAA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "c2cj", true)]
	[InlineData("f", "", false)]
	[InlineData("", "c2cj", false)]
	public void Validation_AllAreRequiredTimeQualifier(string timeQualifier, string time, bool isValidExpected)
	{
		var subject = new G62_DateTime();
		//Required fields
		//Test Parameters
		subject.TimeQualifier = timeQualifier;
		subject.Time = time;
		//At Least one
		subject.DateQualifier = "al";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "al";
			subject.Date = "BUdul2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
