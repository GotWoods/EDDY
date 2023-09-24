using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class JLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JL*En*GjAGrn*9Qmc*lD";

		var expected = new JL_JournalIdentification()
		{
			StandardCarrierAlphaCode = "En",
			Date = "GjAGrn",
			Time = "9Qmc",
			Name30CharacterFormat = "lD",
		};

		var actual = Map.MapObject<JL_JournalIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("En", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.Date = "GjAGrn";
		subject.Time = "9Qmc";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GjAGrn", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.StandardCarrierAlphaCode = "En";
		subject.Time = "9Qmc";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9Qmc", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.StandardCarrierAlphaCode = "En";
		subject.Date = "GjAGrn";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
