using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G62Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G62*fi*AtKT80*u*MZ5e*Q3";

		var expected = new G62_DateTime()
		{
			DateQualifier = "fi",
			Date = "AtKT80",
			TimeQualifier = "u",
			Time = "MZ5e",
			TimeCode = "Q3",
		};

		var actual = Map.MapObject<G62_DateTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fi", "AtKT80", true)]
	[InlineData("fi", "", false)]
	[InlineData("", "AtKT80", false)]
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
			subject.TimeQualifier = "u";
			subject.Time = "MZ5e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("fi", "u", true)]
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
			subject.TimeQualifier = "u";
			subject.Time = "MZ5e";
		}

        if (subject.DateQualifier != "")
            subject.Date = "AAAAAA";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "MZ5e", true)]
	[InlineData("u", "", false)]
	[InlineData("", "MZ5e", false)]
	public void Validation_AllAreRequiredTimeQualifier(string timeQualifier, string time, bool isValidExpected)
	{
		var subject = new G62_DateTime();
		//Required fields
		//Test Parameters
		subject.TimeQualifier = timeQualifier;
		subject.Time = time;
		//At Least one
		subject.DateQualifier = "fi";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "fi";
			subject.Date = "AtKT80";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
