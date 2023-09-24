using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TMCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TMC*RJN*B7vcB5*CKBK*m";

		var expected = new TMC_TariffModification()
		{
			DateTimeQualifier = "RJN",
			Date = "B7vcB5",
			Time = "CKBK",
			TariffModificationCode = "m",
		};

		var actual = Map.MapObject<TMC_TariffModification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RJN", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new TMC_TariffModification();
		subject.Date = "B7vcB5";
		subject.Time = "CKBK";
		subject.TariffModificationCode = "m";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B7vcB5", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TMC_TariffModification();
		subject.DateTimeQualifier = "RJN";
		subject.Time = "CKBK";
		subject.TariffModificationCode = "m";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CKBK", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new TMC_TariffModification();
		subject.DateTimeQualifier = "RJN";
		subject.Date = "B7vcB5";
		subject.TariffModificationCode = "m";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredTariffModificationCode(string tariffModificationCode, bool isValidExpected)
	{
		var subject = new TMC_TariffModification();
		subject.DateTimeQualifier = "RJN";
		subject.Date = "B7vcB5";
		subject.Time = "CKBK";
		subject.TariffModificationCode = tariffModificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
