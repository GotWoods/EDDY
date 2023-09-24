using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class JLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "JL*fW*NP2sgPXZ*mV4T*uR";

		var expected = new JL_JournalIdentification()
		{
			StandardCarrierAlphaCode = "fW",
			Date = "NP2sgPXZ",
			Time = "mV4T",
			Name30CharacterFormat = "uR",
		};

		var actual = Map.MapObject<JL_JournalIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fW", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.Date = "NP2sgPXZ";
		subject.Time = "mV4T";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NP2sgPXZ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.StandardCarrierAlphaCode = "fW";
		subject.Time = "mV4T";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mV4T", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new JL_JournalIdentification();
		subject.StandardCarrierAlphaCode = "fW";
		subject.Date = "NP2sgPXZ";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
