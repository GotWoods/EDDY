using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class GRPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GRP*9*J*wHOaC1c9*qOu5EnFI";

		var expected = new GRP_GroupDosageParameters()
		{
			Number = 9,
			UnitDoseCode = "J",
			Date = "wHOaC1c9",
			Date2 = "qOu5EnFI",
		};

		var actual = Map.MapObject<GRP_GroupDosageParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new GRP_GroupDosageParameters();
		//Required fields
		subject.UnitDoseCode = "J";
		subject.Date = "wHOaC1c9";
		subject.Date2 = "qOu5EnFI";
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredUnitDoseCode(string unitDoseCode, bool isValidExpected)
	{
		var subject = new GRP_GroupDosageParameters();
		//Required fields
		subject.Number = 9;
		subject.Date = "wHOaC1c9";
		subject.Date2 = "qOu5EnFI";
		//Test Parameters
		subject.UnitDoseCode = unitDoseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wHOaC1c9", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new GRP_GroupDosageParameters();
		//Required fields
		subject.Number = 9;
		subject.UnitDoseCode = "J";
		subject.Date2 = "qOu5EnFI";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qOu5EnFI", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new GRP_GroupDosageParameters();
		//Required fields
		subject.Number = 9;
		subject.UnitDoseCode = "J";
		subject.Date = "wHOaC1c9";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
