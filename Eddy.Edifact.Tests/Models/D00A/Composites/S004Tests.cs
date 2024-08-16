using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S004Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "zaSIwlkZ:ALR6";

		var expected = new S004_DateAndTimeOfPreparation()
		{
			Date = "zaSIwlkZ",
			Time = "ALR6",
		};

		var actual = Map.MapComposite<S004_DateAndTimeOfPreparation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zaSIwlkZ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new S004_DateAndTimeOfPreparation();
		//Required fields
		subject.Time = "ALR6";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ALR6", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new S004_DateAndTimeOfPreparation();
		//Required fields
		subject.Date = "zaSIwlkZ";
		//Test Parameters
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
