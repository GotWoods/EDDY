using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class TMCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TMC*2rM*xxfPsh*J8e9*W";

		var expected = new TMC_TariffModification()
		{
			DateTimeQualifier = "2rM",
			Date = "xxfPsh",
			Time = "J8e9",
			TariffModificationCode = "W",
		};

		var actual = Map.MapObject<TMC_TariffModification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2rM", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new TMC_TariffModification();
		subject.Date = "xxfPsh";
		subject.Time = "J8e9";
		subject.TariffModificationCode = "W";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xxfPsh", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TMC_TariffModification();
		subject.DateTimeQualifier = "2rM";
		subject.Time = "J8e9";
		subject.TariffModificationCode = "W";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J8e9", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new TMC_TariffModification();
		subject.DateTimeQualifier = "2rM";
		subject.Date = "xxfPsh";
		subject.TariffModificationCode = "W";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredTariffModificationCode(string tariffModificationCode, bool isValidExpected)
	{
		var subject = new TMC_TariffModification();
		subject.DateTimeQualifier = "2rM";
		subject.Date = "xxfPsh";
		subject.Time = "J8e9";
		subject.TariffModificationCode = tariffModificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
