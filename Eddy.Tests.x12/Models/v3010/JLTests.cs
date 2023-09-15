using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class JLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JL*Do*iwXdo9*4rd3*NJ";

		var expected = new JL_JournalIdentification()
		{
			StandardCarrierAlphaCode = "Do",
			Date = "iwXdo9",
			Time = "4rd3",
			Name30CharacterFormat = "NJ",
		};

		var actual = Map.MapObject<JL_JournalIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Do", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.Date = "iwXdo9";
		subject.Time = "4rd3";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iwXdo9", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.StandardCarrierAlphaCode = "Do";
		subject.Time = "4rd3";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4rd3", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.StandardCarrierAlphaCode = "Do";
		subject.Date = "iwXdo9";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
