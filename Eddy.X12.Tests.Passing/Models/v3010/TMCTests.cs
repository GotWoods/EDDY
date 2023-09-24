using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TMCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TMC*Ihk*R3raRp*G2eH*x";

		var expected = new TMC_TariffModification()
		{
			DateTimeQualifier = "Ihk",
			Date = "R3raRp",
			Time = "G2eH",
			TariffModificationCode = "x",
		};

		var actual = Map.MapObject<TMC_TariffModification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ihk", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new TMC_TariffModification();
		subject.Date = "R3raRp";
		subject.Time = "G2eH";
		subject.TariffModificationCode = "x";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R3raRp", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new TMC_TariffModification();
		subject.DateTimeQualifier = "Ihk";
		subject.Time = "G2eH";
		subject.TariffModificationCode = "x";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G2eH", true)]
	public void Validation_RequiredTime(string time, bool isValidExpected)
	{
		var subject = new TMC_TariffModification();
		subject.DateTimeQualifier = "Ihk";
		subject.Date = "R3raRp";
		subject.TariffModificationCode = "x";
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredTariffModificationCode(string tariffModificationCode, bool isValidExpected)
	{
		var subject = new TMC_TariffModification();
		subject.DateTimeQualifier = "Ihk";
		subject.Date = "R3raRp";
		subject.Time = "G2eH";
		subject.TariffModificationCode = tariffModificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
