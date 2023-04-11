using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class JLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JL*to*cbo2JeTZ*4jUV*m";

		var expected = new JL_JournalIdentification()
		{
			StandardCarrierAlphaCode = "to",
			Date = "cbo2JeTZ",
			Time = "4jUV",
			Name = "m",
		};

		var actual = Map.MapObject<JL_JournalIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("to", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.Date = "cbo2JeTZ";
		subject.Time = "4jUV";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cbo2JeTZ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.StandardCarrierAlphaCode = "to";
		subject.Time = "4jUV";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4jUV", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.StandardCarrierAlphaCode = "to";
		subject.Date = "cbo2JeTZ";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
