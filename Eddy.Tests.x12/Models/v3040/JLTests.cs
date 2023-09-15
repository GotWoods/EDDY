using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class JLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JL*t9*NwTBkO*DIvb*Mg";

		var expected = new JL_JournalIdentification()
		{
			StandardCarrierAlphaCode = "t9",
			Date = "NwTBkO",
			Time = "DIvb",
			Name30CharacterFormat = "Mg",
		};

		var actual = Map.MapObject<JL_JournalIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t9", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.Date = "NwTBkO";
		subject.Time = "DIvb";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NwTBkO", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.StandardCarrierAlphaCode = "t9";
		subject.Time = "DIvb";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DIvb", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.StandardCarrierAlphaCode = "t9";
		subject.Date = "NwTBkO";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
