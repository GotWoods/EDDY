using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CYCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CYC*2784*h2*2*zpnJVB*uA*55BMpCp";

		var expected = new CYC_CarHireCycle()
		{
			Year = 2784,
			MonthOfTheYearCode = "h2",
			CycleMonthHours = 2,
			StandardPointLocationCode = "zpnJVB",
			StandardCarrierAlphaCode = "uA",
			AssociationOfAmericanRailroadsAARPoolCode = "55BMpCp",
		};

		var actual = Map.MapObject<CYC_CarHireCycle>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2784, true)]
	public void Validatation_RequiredYear(int year, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		subject.MonthOfTheYearCode = "h2";
		subject.CycleMonthHours = 2;
		subject.StandardPointLocationCode = "zpnJVB";
		subject.StandardCarrierAlphaCode = "uA";
		if (year > 0)
		subject.Year = year;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h2", true)]
	public void Validatation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		subject.Year = 2784;
		subject.CycleMonthHours = 2;
		subject.StandardPointLocationCode = "zpnJVB";
		subject.StandardCarrierAlphaCode = "uA";
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validatation_RequiredCycleMonthHours(int cycleMonthHours, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		subject.Year = 2784;
		subject.MonthOfTheYearCode = "h2";
		subject.StandardPointLocationCode = "zpnJVB";
		subject.StandardCarrierAlphaCode = "uA";
		if (cycleMonthHours > 0)
		subject.CycleMonthHours = cycleMonthHours;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zpnJVB", true)]
	public void Validatation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		subject.Year = 2784;
		subject.MonthOfTheYearCode = "h2";
		subject.CycleMonthHours = 2;
		subject.StandardCarrierAlphaCode = "uA";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uA", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		subject.Year = 2784;
		subject.MonthOfTheYearCode = "h2";
		subject.CycleMonthHours = 2;
		subject.StandardPointLocationCode = "zpnJVB";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
