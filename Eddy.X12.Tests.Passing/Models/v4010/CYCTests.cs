using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CYCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CYC*8193*A8*5*0QnP2U*5m*HBEqnmw";

		var expected = new CYC_CarHireCycle()
		{
			Year = 8193,
			MonthOfTheYearCode = "A8",
			CycleMonthHours = 5,
			StandardPointLocationCode = "0QnP2U",
			StandardCarrierAlphaCode = "5m",
			AssociationOfAmericanRailroadsAARPoolCode = "HBEqnmw",
		};

		var actual = Map.MapObject<CYC_CarHireCycle>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8193, true)]
	public void Validation_RequiredYear(int year, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		//Required fields
		subject.MonthOfTheYearCode = "A8";
		subject.CycleMonthHours = 5;
		subject.StandardPointLocationCode = "0QnP2U";
		subject.StandardCarrierAlphaCode = "5m";
		//Test Parameters
		if (year > 0) 
			subject.Year = year;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A8", true)]
	public void Validation_RequiredMonthOfTheYearCode(string monthOfTheYearCode, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		//Required fields
		subject.Year = 8193;
		subject.CycleMonthHours = 5;
		subject.StandardPointLocationCode = "0QnP2U";
		subject.StandardCarrierAlphaCode = "5m";
		//Test Parameters
		subject.MonthOfTheYearCode = monthOfTheYearCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredCycleMonthHours(int cycleMonthHours, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		//Required fields
		subject.Year = 8193;
		subject.MonthOfTheYearCode = "A8";
		subject.StandardPointLocationCode = "0QnP2U";
		subject.StandardCarrierAlphaCode = "5m";
		//Test Parameters
		if (cycleMonthHours > 0) 
			subject.CycleMonthHours = cycleMonthHours;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0QnP2U", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		//Required fields
		subject.Year = 8193;
		subject.MonthOfTheYearCode = "A8";
		subject.CycleMonthHours = 5;
		subject.StandardCarrierAlphaCode = "5m";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5m", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new CYC_CarHireCycle();
		//Required fields
		subject.Year = 8193;
		subject.MonthOfTheYearCode = "A8";
		subject.CycleMonthHours = 5;
		subject.StandardPointLocationCode = "0QnP2U";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
