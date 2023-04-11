using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class GRPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GRP*3*F*KKRYe78B*ITVPmwX2";

		var expected = new GRP_GroupDosageParameters()
		{
			Number = 3,
			UnitDoseCode = "F",
			Date = "KKRYe78B",
			Date2 = "ITVPmwX2",
		};

		var actual = Map.MapObject<GRP_GroupDosageParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new GRP_GroupDosageParameters();
		subject.UnitDoseCode = "F";
		subject.Date = "KKRYe78B";
		subject.Date2 = "ITVPmwX2";
		if (number > 0)
		subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredUnitDoseCode(string unitDoseCode, bool isValidExpected)
	{
		var subject = new GRP_GroupDosageParameters();
		subject.Number = 3;
		subject.Date = "KKRYe78B";
		subject.Date2 = "ITVPmwX2";
		subject.UnitDoseCode = unitDoseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KKRYe78B", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new GRP_GroupDosageParameters();
		subject.Number = 3;
		subject.UnitDoseCode = "F";
		subject.Date2 = "ITVPmwX2";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ITVPmwX2", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new GRP_GroupDosageParameters();
		subject.Number = 3;
		subject.UnitDoseCode = "F";
		subject.Date = "KKRYe78B";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
