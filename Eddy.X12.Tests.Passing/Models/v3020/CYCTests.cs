using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class CYCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CYC*61*65*Un*9*DQiZh3*hy*tqktLFk";

		var expected = new CYC_CarHireCycle()
		{
			Century = 61,
			YearWithinCentury = 65,
			MonthOfTheYearCode = "Un",
			CycleMonthHours = 9,
			StandardPointLocationCode = "DQiZh3",
			StandardCarrierAlphaCode = "hy",
			AssociationOfAmericanRailroadsAARPoolCode = "tqktLFk",
		};

		var actual = Map.MapObject<CYC_CarHireCycle>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(61, true)]
	public void Validation_RequiredCentury(int century, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		//Required fields
		subject.YearWithinCentury = 65;
		subject.MonthOfTheYearCode = "Un";
		subject.CycleMonthHours = 9;
		subject.StandardPointLocationCode = "DQiZh3";
		subject.StandardCarrierAlphaCode = "hy";
		//Test Parameters
		if (century > 0) 
			subject.Century = century;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(65, true)]
	public void Validation_RequiredYearWithinCentury(int yearWithinCentury, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		//Required fields
		subject.Century = 61;
		subject.MonthOfTheYearCode = "Un";
		subject.CycleMonthHours = 9;
		subject.StandardPointLocationCode = "DQiZh3";
		subject.StandardCarrierAlphaCode = "hy";
		//Test Parameters
		if (yearWithinCentury > 0) 
			subject.YearWithinCentury = yearWithinCentury;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Un", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		//Required fields
		subject.Century = 61;
		subject.YearWithinCentury = 65;
		subject.CycleMonthHours = 9;
		subject.StandardPointLocationCode = "DQiZh3";
		subject.StandardCarrierAlphaCode = "hy";
		//Test Parameters
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredCycleMonthHours(int cycleMonthHours, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		//Required fields
		subject.Century = 61;
		subject.YearWithinCentury = 65;
		subject.MonthOfTheYearCode = "Un";
		subject.StandardPointLocationCode = "DQiZh3";
		subject.StandardCarrierAlphaCode = "hy";
		//Test Parameters
		if (cycleMonthHours > 0) 
			subject.CycleMonthHours = cycleMonthHours;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DQiZh3", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		//Required fields
		subject.Century = 61;
		subject.YearWithinCentury = 65;
		subject.MonthOfTheYearCode = "Un";
		subject.CycleMonthHours = 9;
		subject.StandardCarrierAlphaCode = "hy";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hy", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		//Required fields
		subject.Century = 61;
		subject.YearWithinCentury = 65;
		subject.MonthOfTheYearCode = "Un";
		subject.CycleMonthHours = 9;
		subject.StandardPointLocationCode = "DQiZh3";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
