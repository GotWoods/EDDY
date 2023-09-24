using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G62Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G62*Kn*dMwF1gEB*z*5gPz*Mz";

		var expected = new G62_DateTime()
		{
			DateQualifier = "Kn",
			Date = "dMwF1gEB",
			TimeQualifier = "z",
			Time = "5gPz",
			TimeCode = "Mz",
		};

		var actual = Map.MapObject<G62_DateTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Kn", "dMwF1gEB", true)]
	[InlineData("Kn", "", false)]
	[InlineData("", "dMwF1gEB", false)]
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
			subject.TimeQualifier = "z";
			subject.Time = "5gPz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Kn", "z", true)]
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
			subject.TimeQualifier = "z";
			subject.Time = "5gPz";
		}

        if (subject.DateQualifier != "")
            subject.Date = "AAAAAAAA";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z", "5gPz", true)]
	[InlineData("z", "", false)]
	[InlineData("", "5gPz", false)]
	public void Validation_AllAreRequiredTimeQualifier(string timeQualifier, string time, bool isValidExpected)
	{
		var subject = new G62_DateTime();
		//Required fields
		//Test Parameters
		subject.TimeQualifier = timeQualifier;
		subject.Time = time;
		//At Least one
		subject.DateQualifier = "Kn";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.DateQualifier) || !string.IsNullOrEmpty(subject.Date))
		{
			subject.DateQualifier = "Kn";
			subject.Date = "dMwF1gEB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
