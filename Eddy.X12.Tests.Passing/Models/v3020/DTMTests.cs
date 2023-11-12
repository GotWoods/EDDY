using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class DTMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DTM*3hZ*aMPFJD*bxmx*A7*33";

		var expected = new DTM_DateTimeReference()
		{
			DateTimeQualifier = "3hZ",
			Date = "aMPFJD",
			Time = "bxmx",
			TimeCode = "A7",
			Century = 33,
		};

		var actual = Map.MapObject<DTM_DateTimeReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3hZ", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new DTM_DateTimeReference();
		subject.DateTimeQualifier = dateTimeQualifier;
			subject.Date = "aMPFJD";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("aMPFJD", "bxmx", true)]
	[InlineData("aMPFJD", "", true)]
	[InlineData("", "bxmx", true)]
	public void Validation_AtLeastOneDate(string date, string time, bool isValidExpected)
	{
		var subject = new DTM_DateTimeReference();
		subject.DateTimeQualifier = "3hZ";
		subject.Date = date;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
